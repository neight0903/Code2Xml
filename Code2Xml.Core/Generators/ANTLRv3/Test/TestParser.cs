using Code2Xml.Core.Generators.ANTLRv3;
using Code2Xml.Core.SyntaxTree;
using System;
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 3.5.0.2
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// $ANTLR 3.5.0.2 C:\\Users\\exKAZUu\\Projects\\Code2Xml\\Code2Xml.Core\\Generators\\ANTLRv3\\Test\\Test.g 2014-11-03 05:30:21

// The variable 'variable' is assigned but its value is never used.
#pragma warning disable 219
// Unreachable code detected.
#pragma warning disable 162
// Missing XML comment for publicly visible type or member 'Type_or_Member'
#pragma warning disable 1591
// CLS compliance checking will not be performed on 'type' because it is not visible from outside this assembly.
#pragma warning disable 3019


using System.Collections.Generic;
using Antlr.Runtime;
using Antlr.Runtime.Misc;


using Antlr.Runtime.Tree;
using RewriteRuleITokenStream = Antlr.Runtime.Tree.RewriteRuleTokenStream;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "3.5.0.2")]
[System.CLSCompliant(false)]
public partial class TestParser : Antlr.Runtime.Parser, ICustomizedAntlr3Parser
{
	internal static readonly string[] tokenNames = new string[] {
		"<invalid>", "<EOR>", "<DOWN>", "<UP>", "DECIMAL_DIGIT", "Decimal_digits", "Identifier", "IdentifierPart", "IdentifierStart", "IntegerLiteral", "WS", "'('", "')'", "'*'", "'+'", "'='"
	};
	public const int EOF=-1;
	public const int DECIMAL_DIGIT=4;
	public const int Decimal_digits=5;
	public const int Identifier=6;
	public const int IdentifierPart=7;
	public const int IdentifierStart=8;
	public const int IntegerLiteral=9;
	public const int WS=10;
	public const int T__11=11;
	public const int T__12=12;
	public const int T__13=13;
	public const int T__14=14;
	public const int T__15=15;

	public TestParser(ITokenStream input)
		: this(input, new RecognizerSharedState())
	{
	}
	public TestParser(ITokenStream input, RecognizerSharedState state)
		: base(input, state)
	{
		this.state.ruleMemo = new System.Collections.Generic.Dictionary<int, int>[12+1];


		CstBuilderForAntlr3 treeAdaptor = default(CstBuilderForAntlr3);
		CreateTreeAdaptor(ref treeAdaptor);
		TreeAdaptor = treeAdaptor;
		OnCreated();
	}
	// Implement this function in your helper file to use a custom tree adaptor
	partial void CreateTreeAdaptor(ref CstBuilderForAntlr3 adaptor);

	private CstBuilderForAntlr3 adaptor;

	public CstBuilderForAntlr3 TreeAdaptor
	{
		get
		{
			return adaptor;
		}

		set
		{
			this.adaptor = value;
		}
	}

	public override string[] TokenNames { get { return TestParser.tokenNames; } }
	public override string GrammarFileName { get { return "C:\\Users\\exKAZUu\\Projects\\Code2Xml\\Code2Xml.Core\\Generators\\ANTLRv3\\Test\\Test.g"; } }


	partial void OnCreated();
	partial void EnterRule(string ruleName, int ruleIndex);
	partial void LeaveRule(string ruleName, int ruleIndex);

	#region Rules
	partial void EnterRule_compilation_unit();
	partial void LeaveRule_compilation_unit();
	// $ANTLR start "compilation_unit"
	// C:\\Users\\exKAZUu\\Projects\\Code2Xml\\Code2Xml.Core\\Generators\\ANTLRv3\\Test\\Test.g:11:1: public compilation_unit : ( assignment )+ ;
	[GrammarRule("compilation_unit")]
	public CstNode compilation_unit()
	{
		EnterRule_compilation_unit();
		EnterRule("compilation_unit", 1);
		var retval = new CstNode("compilation_unit");
		
		var retval_Start = (IToken)input.LT(1);
		int compilation_unit_StartIndex = input.Index;

		object root_0 = default(object);

		CstNode assignment1 = default(CstNode);

		try { DebugEnterRule(GrammarFileName, "compilation_unit");
		DebugLocation(11, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 1)) { return retval; }

			// C:\\Users\\exKAZUu\\Projects\\Code2Xml\\Code2Xml.Core\\Generators\\ANTLRv3\\Test\\Test.g:12:2: ( ( assignment )+ )
			DebugEnterAlt(1);
			// C:\\Users\\exKAZUu\\Projects\\Code2Xml\\Code2Xml.Core\\Generators\\ANTLRv3\\Test\\Test.g:12:4: ( assignment )+
			{
			

			DebugLocation(12, 4);
			// C:\\Users\\exKAZUu\\Projects\\Code2Xml\\Code2Xml.Core\\Generators\\ANTLRv3\\Test\\Test.g:12:4: ( assignment )+
			int cnt1=0;
			try { DebugEnterSubRule(1);
			while (true)
			{
				int alt1=2;
				try { DebugEnterDecision(1, false);
				int LA1_1 = input.LA(1);

				if ((LA1_1==Identifier||LA1_1==IntegerLiteral||LA1_1==11))
				{
					alt1 = 1;
				}


				} finally { DebugExitDecision(1); }
				switch (alt1)
				{
				case 1:
					DebugEnterAlt(1);
					// C:\\Users\\exKAZUu\\Projects\\Code2Xml\\Code2Xml.Core\\Generators\\ANTLRv3\\Test\\Test.g:12:4: assignment
					{
					DebugLocation(12, 4);
					PushFollow(Follow._assignment_in_compilation_unit69);
					assignment1=assignment();
					PopFollow();
					if (state.failed) return retval;
					if (state.backtracking == 0) adaptor.AddChild(retval, assignment1, "assignment1");

					}
					break;

				default:
					if (cnt1 >= 1)
						goto loop1;

					if (state.backtracking>0) {state.failed=true; return retval;}
					EarlyExitException eee1 = new EarlyExitException( 1, input );
					DebugRecognitionException(eee1);
					throw eee1;
				}
				cnt1++;
			}
			loop1:
				;

			} finally { DebugExitSubRule(1); }


			}

			

			if (state.backtracking == 0) {
			
			
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
			adaptor.ErrorNode(input, retval_Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("compilation_unit", 1);
			LeaveRule("compilation_unit", 1);
			LeaveRule_compilation_unit();
			if (state.backtracking > 0) { Memoize(input, 1, compilation_unit_StartIndex); }

		}
		DebugLocation(13, 1);
		} finally { DebugExitRule(GrammarFileName, "compilation_unit"); }
		return retval;

	}
	// $ANTLR end "compilation_unit"

	partial void EnterRule_assignment();
	partial void LeaveRule_assignment();
	// $ANTLR start "assignment"
	// C:\\Users\\exKAZUu\\Projects\\Code2Xml\\Code2Xml.Core\\Generators\\ANTLRv3\\Test\\Test.g:15:1: assignment : ( Identifier '=' assignment | addition );
	[GrammarRule("assignment")]
	private CstNode assignment()
	{
		EnterRule_assignment();
		EnterRule("assignment", 2);
		var retval = new CstNode("assignment");
		
		var retval_Start = (IToken)input.LT(1);
		int assignment_StartIndex = input.Index;

		object root_0 = default(object);

		IToken Identifier2 = default(IToken);
		IToken char_literal3 = default(IToken);
		CstNode assignment4 = default(CstNode);
		CstNode addition5 = default(CstNode);

		object Identifier2_tree = default(object);
		object char_literal3_tree = default(object);
		try { DebugEnterRule(GrammarFileName, "assignment");
		DebugLocation(15, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 2)) { return retval; }

			// C:\\Users\\exKAZUu\\Projects\\Code2Xml\\Code2Xml.Core\\Generators\\ANTLRv3\\Test\\Test.g:16:2: ( Identifier '=' assignment | addition )
			int alt2=2;
			try { DebugEnterDecision(2, false);
			int LA2_1 = input.LA(1);

			if ((LA2_1==Identifier))
			{
				int LA2_2 = input.LA(2);

				if ((EvaluatePredicate(synpred2_Test_fragment)))
				{
					alt2 = 1;
				}
				else if ((true))
				{
					alt2 = 2;
				}
				else
				{
					if (state.backtracking>0) {state.failed=true; return retval;}
					NoViableAltException nvae = new NoViableAltException("", 2, 1, input, 2);
					DebugRecognitionException(nvae);
					throw nvae;
				}
			}
			else if ((LA2_1==IntegerLiteral||LA2_1==11))
			{
				alt2 = 2;
			}
			else
			{
				if (state.backtracking>0) {state.failed=true; return retval;}
				NoViableAltException nvae = new NoViableAltException("", 2, 0, input, 1);
				DebugRecognitionException(nvae);
				throw nvae;
			}
			} finally { DebugExitDecision(2); }
			switch (alt2)
			{
			case 1:
				DebugEnterAlt(1);
				// C:\\Users\\exKAZUu\\Projects\\Code2Xml\\Code2Xml.Core\\Generators\\ANTLRv3\\Test\\Test.g:16:4: Identifier '=' assignment
				{
				

				DebugLocation(16, 4);
				Identifier2=(IToken)Match(input,Identifier,Follow._Identifier_in_assignment81); if (state.failed) return retval;
				if (state.backtracking == 0) {
adaptor.Create(retval, Identifier2, "Identifier2");
				
				}
				DebugLocation(16, 15);
				char_literal3=(IToken)Match(input,15,Follow._15_in_assignment83); if (state.failed) return retval;
				if (state.backtracking == 0) {
adaptor.Create(retval, char_literal3, "char_literal3");
				
				}
				DebugLocation(16, 19);
				PushFollow(Follow._assignment_in_assignment85);
				assignment4=assignment();
				PopFollow();
				if (state.failed) return retval;
				if (state.backtracking == 0) adaptor.AddChild(retval, assignment4, "assignment4");

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// C:\\Users\\exKAZUu\\Projects\\Code2Xml\\Code2Xml.Core\\Generators\\ANTLRv3\\Test\\Test.g:17:4: addition
				{
				

				DebugLocation(17, 4);
				PushFollow(Follow._addition_in_assignment90);
				addition5=addition();
				PopFollow();
				if (state.failed) return retval;
				if (state.backtracking == 0) adaptor.AddChild(retval, addition5, "addition5");

				}
				break;

			}
			

			if (state.backtracking == 0) {
			
			
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
			adaptor.ErrorNode(input, retval_Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("assignment", 2);
			LeaveRule("assignment", 2);
			LeaveRule_assignment();
			if (state.backtracking > 0) { Memoize(input, 2, assignment_StartIndex); }

		}
		DebugLocation(18, 1);
		} finally { DebugExitRule(GrammarFileName, "assignment"); }
		return retval;

	}
	// $ANTLR end "assignment"

	partial void EnterRule_addition();
	partial void LeaveRule_addition();
	// $ANTLR start "addition"
	// C:\\Users\\exKAZUu\\Projects\\Code2Xml\\Code2Xml.Core\\Generators\\ANTLRv3\\Test\\Test.g:20:1: addition : multiplication ( '+' multiplication )* ;
	[GrammarRule("addition")]
	private CstNode addition()
	{
		EnterRule_addition();
		EnterRule("addition", 3);
		var retval = new CstNode("addition");
		
		var retval_Start = (IToken)input.LT(1);
		int addition_StartIndex = input.Index;

		object root_0 = default(object);

		IToken char_literal7 = default(IToken);
		CstNode multiplication6 = default(CstNode);
		CstNode multiplication8 = default(CstNode);

		object char_literal7_tree = default(object);
		try { DebugEnterRule(GrammarFileName, "addition");
		DebugLocation(20, 4);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 3)) { return retval; }

			// C:\\Users\\exKAZUu\\Projects\\Code2Xml\\Code2Xml.Core\\Generators\\ANTLRv3\\Test\\Test.g:21:5: ( multiplication ( '+' multiplication )* )
			DebugEnterAlt(1);
			// C:\\Users\\exKAZUu\\Projects\\Code2Xml\\Code2Xml.Core\\Generators\\ANTLRv3\\Test\\Test.g:21:7: multiplication ( '+' multiplication )*
			{
			

			DebugLocation(21, 7);
			PushFollow(Follow._multiplication_in_addition104);
			multiplication6=multiplication();
			PopFollow();
			if (state.failed) return retval;
			if (state.backtracking == 0) adaptor.AddChild(retval, multiplication6, "multiplication6");
			DebugLocation(21, 22);
			// C:\\Users\\exKAZUu\\Projects\\Code2Xml\\Code2Xml.Core\\Generators\\ANTLRv3\\Test\\Test.g:21:22: ( '+' multiplication )*
			try { DebugEnterSubRule(3);
			while (true)
			{
				int alt3=2;
				try { DebugEnterDecision(3, false);
				int LA3_1 = input.LA(1);

				if ((LA3_1==14))
				{
					int LA3_2 = input.LA(2);

					if ((EvaluatePredicate(synpred3_Test_fragment)))
					{
						alt3 = 1;
					}


				}


				} finally { DebugExitDecision(3); }
				switch ( alt3 )
				{
				case 1:
					DebugEnterAlt(1);
					// C:\\Users\\exKAZUu\\Projects\\Code2Xml\\Code2Xml.Core\\Generators\\ANTLRv3\\Test\\Test.g:21:23: '+' multiplication
					{
					DebugLocation(21, 23);
					char_literal7=(IToken)Match(input,14,Follow._14_in_addition107); if (state.failed) return retval;
					if (state.backtracking == 0) {
adaptor.Create(retval, char_literal7, "char_literal7");
					
					}
					DebugLocation(21, 27);
					PushFollow(Follow._multiplication_in_addition109);
					multiplication8=multiplication();
					PopFollow();
					if (state.failed) return retval;
					if (state.backtracking == 0) adaptor.AddChild(retval, multiplication8, "multiplication8");

					}
					break;

				default:
					goto loop3;
				}
			}

			loop3:
				;

			} finally { DebugExitSubRule(3); }


			}

			

			if (state.backtracking == 0) {
			
			
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
			adaptor.ErrorNode(input, retval_Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("addition", 3);
			LeaveRule("addition", 3);
			LeaveRule_addition();
			if (state.backtracking > 0) { Memoize(input, 3, addition_StartIndex); }

		}
		DebugLocation(22, 4);
		} finally { DebugExitRule(GrammarFileName, "addition"); }
		return retval;

	}
	// $ANTLR end "addition"

	partial void EnterRule_multiplication();
	partial void LeaveRule_multiplication();
	// $ANTLR start "multiplication"
	// C:\\Users\\exKAZUu\\Projects\\Code2Xml\\Code2Xml.Core\\Generators\\ANTLRv3\\Test\\Test.g:24:1: multiplication : primary ( '*' primary )* ;
	[GrammarRule("multiplication")]
	private CstNode multiplication()
	{
		EnterRule_multiplication();
		EnterRule("multiplication", 4);
		var retval = new CstNode("multiplication");
		
		var retval_Start = (IToken)input.LT(1);
		int multiplication_StartIndex = input.Index;

		object root_0 = default(object);

		IToken char_literal10 = default(IToken);
		CstNode primary9 = default(CstNode);
		CstNode primary11 = default(CstNode);

		object char_literal10_tree = default(object);
		try { DebugEnterRule(GrammarFileName, "multiplication");
		DebugLocation(24, 4);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 4)) { return retval; }

			// C:\\Users\\exKAZUu\\Projects\\Code2Xml\\Code2Xml.Core\\Generators\\ANTLRv3\\Test\\Test.g:25:5: ( primary ( '*' primary )* )
			DebugEnterAlt(1);
			// C:\\Users\\exKAZUu\\Projects\\Code2Xml\\Code2Xml.Core\\Generators\\ANTLRv3\\Test\\Test.g:25:7: primary ( '*' primary )*
			{
			

			DebugLocation(25, 7);
			PushFollow(Follow._primary_in_multiplication128);
			primary9=primary();
			PopFollow();
			if (state.failed) return retval;
			if (state.backtracking == 0) adaptor.AddChild(retval, primary9, "primary9");
			DebugLocation(25, 15);
			// C:\\Users\\exKAZUu\\Projects\\Code2Xml\\Code2Xml.Core\\Generators\\ANTLRv3\\Test\\Test.g:25:15: ( '*' primary )*
			try { DebugEnterSubRule(4);
			while (true)
			{
				int alt4=2;
				try { DebugEnterDecision(4, false);
				int LA4_1 = input.LA(1);

				if ((LA4_1==13))
				{
					int LA4_2 = input.LA(2);

					if ((EvaluatePredicate(synpred4_Test_fragment)))
					{
						alt4 = 1;
					}


				}


				} finally { DebugExitDecision(4); }
				switch ( alt4 )
				{
				case 1:
					DebugEnterAlt(1);
					// C:\\Users\\exKAZUu\\Projects\\Code2Xml\\Code2Xml.Core\\Generators\\ANTLRv3\\Test\\Test.g:25:16: '*' primary
					{
					DebugLocation(25, 16);
					char_literal10=(IToken)Match(input,13,Follow._13_in_multiplication131); if (state.failed) return retval;
					if (state.backtracking == 0) {
adaptor.Create(retval, char_literal10, "char_literal10");
					
					}
					DebugLocation(25, 20);
					PushFollow(Follow._primary_in_multiplication133);
					primary11=primary();
					PopFollow();
					if (state.failed) return retval;
					if (state.backtracking == 0) adaptor.AddChild(retval, primary11, "primary11");

					}
					break;

				default:
					goto loop4;
				}
			}

			loop4:
				;

			} finally { DebugExitSubRule(4); }


			}

			

			if (state.backtracking == 0) {
			
			
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
			adaptor.ErrorNode(input, retval_Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("multiplication", 4);
			LeaveRule("multiplication", 4);
			LeaveRule_multiplication();
			if (state.backtracking > 0) { Memoize(input, 4, multiplication_StartIndex); }

		}
		DebugLocation(26, 4);
		} finally { DebugExitRule(GrammarFileName, "multiplication"); }
		return retval;

	}
	// $ANTLR end "multiplication"

	partial void EnterRule_primary();
	partial void LeaveRule_primary();
	// $ANTLR start "primary"
	// C:\\Users\\exKAZUu\\Projects\\Code2Xml\\Code2Xml.Core\\Generators\\ANTLRv3\\Test\\Test.g:28:1: primary : ( Identifier | IntegerLiteral | '(' assignment ')' | Identifier '=' assignment );
	[GrammarRule("primary")]
	private CstNode primary()
	{
		EnterRule_primary();
		EnterRule("primary", 5);
		var retval = new CstNode("primary");
		
		var retval_Start = (IToken)input.LT(1);
		int primary_StartIndex = input.Index;

		object root_0 = default(object);

		IToken Identifier12 = default(IToken);
		IToken IntegerLiteral13 = default(IToken);
		IToken char_literal14 = default(IToken);
		IToken char_literal16 = default(IToken);
		IToken Identifier17 = default(IToken);
		IToken char_literal18 = default(IToken);
		CstNode assignment15 = default(CstNode);
		CstNode assignment19 = default(CstNode);

		object Identifier12_tree = default(object);
		object IntegerLiteral13_tree = default(object);
		object char_literal14_tree = default(object);
		object char_literal16_tree = default(object);
		object Identifier17_tree = default(object);
		object char_literal18_tree = default(object);
		try { DebugEnterRule(GrammarFileName, "primary");
		DebugLocation(28, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 5)) { return retval; }

			// C:\\Users\\exKAZUu\\Projects\\Code2Xml\\Code2Xml.Core\\Generators\\ANTLRv3\\Test\\Test.g:29:2: ( Identifier | IntegerLiteral | '(' assignment ')' | Identifier '=' assignment )
			int alt5=4;
			try { DebugEnterDecision(5, false);
			switch (input.LA(1))
			{
			case Identifier:
				{
				int LA5_2 = input.LA(2);

				if ((LA5_2==15))
				{
					alt5 = 4;
				}
				else if ((LA5_2==EOF||LA5_2==Identifier||LA5_2==IntegerLiteral||(LA5_2>=11 && LA5_2<=14)))
				{
					alt5 = 1;
				}
				else
				{
					if (state.backtracking>0) {state.failed=true; return retval;}
					NoViableAltException nvae = new NoViableAltException("", 5, 1, input, 2);
					DebugRecognitionException(nvae);
					throw nvae;
				}
				}
				break;
			case IntegerLiteral:
				{
				alt5 = 2;
				}
				break;
			case 11:
				{
				alt5 = 3;
				}
				break;
			default:
				{
					if (state.backtracking>0) {state.failed=true; return retval;}
					NoViableAltException nvae = new NoViableAltException("", 5, 0, input, 1);
					DebugRecognitionException(nvae);
					throw nvae;
				}
			}

			} finally { DebugExitDecision(5); }
			switch (alt5)
			{
			case 1:
				DebugEnterAlt(1);
				// C:\\Users\\exKAZUu\\Projects\\Code2Xml\\Code2Xml.Core\\Generators\\ANTLRv3\\Test\\Test.g:29:4: Identifier
				{
				

				DebugLocation(29, 4);
				Identifier12=(IToken)Match(input,Identifier,Follow._Identifier_in_primary149); if (state.failed) return retval;
				if (state.backtracking == 0) {
adaptor.Create(retval, Identifier12, "Identifier12");
				
				}

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// C:\\Users\\exKAZUu\\Projects\\Code2Xml\\Code2Xml.Core\\Generators\\ANTLRv3\\Test\\Test.g:30:4: IntegerLiteral
				{
				

				DebugLocation(30, 4);
				IntegerLiteral13=(IToken)Match(input,IntegerLiteral,Follow._IntegerLiteral_in_primary154); if (state.failed) return retval;
				if (state.backtracking == 0) {
adaptor.Create(retval, IntegerLiteral13, "IntegerLiteral13");
				
				}

				}
				break;
			case 3:
				DebugEnterAlt(3);
				// C:\\Users\\exKAZUu\\Projects\\Code2Xml\\Code2Xml.Core\\Generators\\ANTLRv3\\Test\\Test.g:31:4: '(' assignment ')'
				{
				

				DebugLocation(31, 4);
				char_literal14=(IToken)Match(input,11,Follow._11_in_primary160); if (state.failed) return retval;
				if (state.backtracking == 0) {
adaptor.Create(retval, char_literal14, "char_literal14");
				
				}
				DebugLocation(31, 8);
				PushFollow(Follow._assignment_in_primary162);
				assignment15=assignment();
				PopFollow();
				if (state.failed) return retval;
				if (state.backtracking == 0) adaptor.AddChild(retval, assignment15, "assignment15");
				DebugLocation(31, 19);
				char_literal16=(IToken)Match(input,12,Follow._12_in_primary164); if (state.failed) return retval;
				if (state.backtracking == 0) {
adaptor.Create(retval, char_literal16, "char_literal16");
				
				}

				}
				break;
			case 4:
				DebugEnterAlt(4);
				// C:\\Users\\exKAZUu\\Projects\\Code2Xml\\Code2Xml.Core\\Generators\\ANTLRv3\\Test\\Test.g:32:4: Identifier '=' assignment
				{
				

				DebugLocation(32, 4);
				Identifier17=(IToken)Match(input,Identifier,Follow._Identifier_in_primary169); if (state.failed) return retval;
				if (state.backtracking == 0) {
adaptor.Create(retval, Identifier17, "Identifier17");
				
				}
				DebugLocation(32, 15);
				char_literal18=(IToken)Match(input,15,Follow._15_in_primary171); if (state.failed) return retval;
				if (state.backtracking == 0) {
adaptor.Create(retval, char_literal18, "char_literal18");
				
				}
				DebugLocation(32, 19);
				PushFollow(Follow._assignment_in_primary173);
				assignment19=assignment();
				PopFollow();
				if (state.failed) return retval;
				if (state.backtracking == 0) adaptor.AddChild(retval, assignment19, "assignment19");

				}
				break;

			}
			

			if (state.backtracking == 0) {
			
			
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
			adaptor.ErrorNode(input, retval_Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("primary", 5);
			LeaveRule("primary", 5);
			LeaveRule_primary();
			if (state.backtracking > 0) { Memoize(input, 5, primary_StartIndex); }

		}
		DebugLocation(33, 1);
		} finally { DebugExitRule(GrammarFileName, "primary"); }
		return retval;

	}
	// $ANTLR end "primary"

	partial void EnterRule_synpred2_Test_fragment();
	partial void LeaveRule_synpred2_Test_fragment();

	// $ANTLR start synpred2_Test
	private void synpred2_Test_fragment()
	{
		EnterRule_synpred2_Test_fragment();
		EnterRule("synpred2_Test_fragment", 7);
		var retval = new CstNode("synpred2_Test_fragment");
		try
		{
			// C:\\Users\\exKAZUu\\Projects\\Code2Xml\\Code2Xml.Core\\Generators\\ANTLRv3\\Test\\Test.g:16:4: ( Identifier '=' assignment )
			DebugEnterAlt(1);
			// C:\\Users\\exKAZUu\\Projects\\Code2Xml\\Code2Xml.Core\\Generators\\ANTLRv3\\Test\\Test.g:16:4: Identifier '=' assignment
			{
			DebugLocation(16, 4);
			Match(input,Identifier,Follow._Identifier_in_synpred2_Test81); if (state.failed) return;
			DebugLocation(16, 15);
			Match(input,15,Follow._15_in_synpred2_Test83); if (state.failed) return;
			DebugLocation(16, 19);
			PushFollow(Follow._assignment_in_synpred2_Test85);
			assignment();
			PopFollow();
			if (state.failed) return;

			}

		}
		finally
		{
			TraceOut("synpred2_Test_fragment", 7);
			LeaveRule("synpred2_Test_fragment", 7);
			LeaveRule_synpred2_Test_fragment();
		}
	}
	// $ANTLR end synpred2_Test

	partial void EnterRule_synpred3_Test_fragment();
	partial void LeaveRule_synpred3_Test_fragment();

	// $ANTLR start synpred3_Test
	private void synpred3_Test_fragment()
	{
		EnterRule_synpred3_Test_fragment();
		EnterRule("synpred3_Test_fragment", 8);
		var retval = new CstNode("synpred3_Test_fragment");
		try
		{
			// C:\\Users\\exKAZUu\\Projects\\Code2Xml\\Code2Xml.Core\\Generators\\ANTLRv3\\Test\\Test.g:21:23: ( '+' multiplication )
			DebugEnterAlt(1);
			// C:\\Users\\exKAZUu\\Projects\\Code2Xml\\Code2Xml.Core\\Generators\\ANTLRv3\\Test\\Test.g:21:23: '+' multiplication
			{
			DebugLocation(21, 23);
			Match(input,14,Follow._14_in_synpred3_Test107); if (state.failed) return;
			DebugLocation(21, 27);
			PushFollow(Follow._multiplication_in_synpred3_Test109);
			multiplication();
			PopFollow();
			if (state.failed) return;

			}

		}
		finally
		{
			TraceOut("synpred3_Test_fragment", 8);
			LeaveRule("synpred3_Test_fragment", 8);
			LeaveRule_synpred3_Test_fragment();
		}
	}
	// $ANTLR end synpred3_Test

	partial void EnterRule_synpred4_Test_fragment();
	partial void LeaveRule_synpred4_Test_fragment();

	// $ANTLR start synpred4_Test
	private void synpred4_Test_fragment()
	{
		EnterRule_synpred4_Test_fragment();
		EnterRule("synpred4_Test_fragment", 9);
		var retval = new CstNode("synpred4_Test_fragment");
		try
		{
			// C:\\Users\\exKAZUu\\Projects\\Code2Xml\\Code2Xml.Core\\Generators\\ANTLRv3\\Test\\Test.g:25:16: ( '*' primary )
			DebugEnterAlt(1);
			// C:\\Users\\exKAZUu\\Projects\\Code2Xml\\Code2Xml.Core\\Generators\\ANTLRv3\\Test\\Test.g:25:16: '*' primary
			{
			DebugLocation(25, 16);
			Match(input,13,Follow._13_in_synpred4_Test131); if (state.failed) return;
			DebugLocation(25, 20);
			PushFollow(Follow._primary_in_synpred4_Test133);
			primary();
			PopFollow();
			if (state.failed) return;

			}

		}
		finally
		{
			TraceOut("synpred4_Test_fragment", 9);
			LeaveRule("synpred4_Test_fragment", 9);
			LeaveRule_synpred4_Test_fragment();
		}
	}
	// $ANTLR end synpred4_Test
	#endregion Rules

	#region Synpreds
	private bool EvaluatePredicate(System.Action fragment)
	{
		bool success = false;
		state.backtracking++;
		try { DebugBeginBacktrack(state.backtracking);
		int start = input.Mark();
		try
		{
			fragment();
		}
		catch ( RecognitionException re )
		{
			System.Console.Error.WriteLine("impossible: "+re);
		}
		success = !state.failed;
		input.Rewind(start);
		} finally { DebugEndBacktrack(state.backtracking, success); }
		state.backtracking--;
		state.failed=false;
		return success;
	}
	#endregion Synpreds


	#region Follow sets
	private static class Follow
	{
		public static readonly BitSet _assignment_in_compilation_unit69 = new BitSet(new ulong[]{0xA42UL});
		public static readonly BitSet _Identifier_in_assignment81 = new BitSet(new ulong[]{0x8000UL});
		public static readonly BitSet _15_in_assignment83 = new BitSet(new ulong[]{0xA40UL});
		public static readonly BitSet _assignment_in_assignment85 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _addition_in_assignment90 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _multiplication_in_addition104 = new BitSet(new ulong[]{0x4002UL});
		public static readonly BitSet _14_in_addition107 = new BitSet(new ulong[]{0xA40UL});
		public static readonly BitSet _multiplication_in_addition109 = new BitSet(new ulong[]{0x4002UL});
		public static readonly BitSet _primary_in_multiplication128 = new BitSet(new ulong[]{0x2002UL});
		public static readonly BitSet _13_in_multiplication131 = new BitSet(new ulong[]{0xA40UL});
		public static readonly BitSet _primary_in_multiplication133 = new BitSet(new ulong[]{0x2002UL});
		public static readonly BitSet _Identifier_in_primary149 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _IntegerLiteral_in_primary154 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _11_in_primary160 = new BitSet(new ulong[]{0xA40UL});
		public static readonly BitSet _assignment_in_primary162 = new BitSet(new ulong[]{0x1000UL});
		public static readonly BitSet _12_in_primary164 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _Identifier_in_primary169 = new BitSet(new ulong[]{0x8000UL});
		public static readonly BitSet _15_in_primary171 = new BitSet(new ulong[]{0xA40UL});
		public static readonly BitSet _assignment_in_primary173 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _Identifier_in_synpred2_Test81 = new BitSet(new ulong[]{0x8000UL});
		public static readonly BitSet _15_in_synpred2_Test83 = new BitSet(new ulong[]{0xA40UL});
		public static readonly BitSet _assignment_in_synpred2_Test85 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _14_in_synpred3_Test107 = new BitSet(new ulong[]{0xA40UL});
		public static readonly BitSet _multiplication_in_synpred3_Test109 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _13_in_synpred4_Test131 = new BitSet(new ulong[]{0xA40UL});
		public static readonly BitSet _primary_in_synpred4_Test133 = new BitSet(new ulong[]{0x2UL});
	}
	#endregion Follow sets
}
