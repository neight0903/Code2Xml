$LOAD_PATH.push('Dependencies/Ruby')
require 'ruby2ruby'
require 'rexml/document'

def traverse_xml(elem)
  arr = Sexp.new(elem.name.to_sym)
  for e in elem.elements
    arr << terminal_node2array_element(e)
  end
  arr
end

def terminal_node2array_element(elem)
  case elem.name
  when 'nil'
    nil
  when 'Symbol'
    elem.text.to_sym
  when 'String'
    elem.text
  when 'Fixnum'
    elem.text.to_i
  when 'Bignum'
    elem.text.to_i
  when 'Float'
    elem.text.to_f
  else
    traverse_xml(elem)
  end
end

STDIN.set_encoding("UTF-8", "UTF-8")
STDOUT.set_encoding("UTF-8", "UTF-8")

doc = REXML::Document.new(STDIN.read())
print Ruby2Ruby.new.process(traverse_xml(doc.root))
