//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 3.5.0.2
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// $ANTLR 3.5.0.2 C:\\Users\\exKAZUu\\Projects\\Code2Xml\\Code2Xml.Languages\\ANTLRv3\\Generators\\Test\\Test.g 2014-04-11 15:27:00

// The variable 'variable' is assigned but its value is never used.
using Antlr.Runtime;
#pragma warning disable 219
// Unreachable code detected.
#pragma warning disable 162
// Missing XML comment for publicly visible type or member 'Type_or_Member'
#pragma warning disable 1591
// CLS compliance checking will not be performed on 'type' because it is not visible from outside this assembly.
#pragma warning disable 3019

namespace Code2Xml.Core.Generators.ANTLRv3.Test {
    [System.CodeDom.Compiler.GeneratedCode("ANTLR", "3.5.0.2")]
    [System.CLSCompliant(false)]
    public partial class TestLexer : Antlr.Runtime.Lexer
    {
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

        // delegates
        // delegators

        public TestLexer()
        {
            OnCreated();
        }

        public TestLexer(ICharStream input )
                : this(input, new RecognizerSharedState())
        {
        }

        public TestLexer(ICharStream input, RecognizerSharedState state)
                : base(input, state)
        {

            OnCreated();
        }
        public override string GrammarFileName { get { return "C:\\Users\\exKAZUu\\Projects\\Code2Xml\\Code2Xml.Languages\\ANTLRv3\\Generators\\Test\\Test.g"; } }


        partial void OnCreated();
        partial void EnterRule(string ruleName, int ruleIndex);
        partial void LeaveRule(string ruleName, int ruleIndex);

        partial void EnterRule_T__11();
        partial void LeaveRule_T__11();

        // $ANTLR start "T__11"
        [GrammarRule("T__11")]
        private void mT__11()
        {
            EnterRule_T__11();
            EnterRule("T__11", 1);
            TraceIn("T__11", 1);
            try
            {
                int _type = T__11;
                int _channel = DefaultTokenChannel;
                // C:\\Users\\exKAZUu\\Projects\\Code2Xml\\Code2Xml.Languages\\ANTLRv3\\Generators\\Test\\Test.g:7:7: ( '(' )
                DebugEnterAlt(1);
                // C:\\Users\\exKAZUu\\Projects\\Code2Xml\\Code2Xml.Languages\\ANTLRv3\\Generators\\Test\\Test.g:7:9: '('
                {
                    DebugLocation(7, 9);
                    Match('('); 

                }

                state.type = _type;
                state.channel = _channel;
            }
            finally
            {
                TraceOut("T__11", 1);
                LeaveRule("T__11", 1);
                LeaveRule_T__11();
            }
        }
        // $ANTLR end "T__11"

        partial void EnterRule_T__12();
        partial void LeaveRule_T__12();

        // $ANTLR start "T__12"
        [GrammarRule("T__12")]
        private void mT__12()
        {
            EnterRule_T__12();
            EnterRule("T__12", 2);
            TraceIn("T__12", 2);
            try
            {
                int _type = T__12;
                int _channel = DefaultTokenChannel;
                // C:\\Users\\exKAZUu\\Projects\\Code2Xml\\Code2Xml.Languages\\ANTLRv3\\Generators\\Test\\Test.g:8:7: ( ')' )
                DebugEnterAlt(1);
                // C:\\Users\\exKAZUu\\Projects\\Code2Xml\\Code2Xml.Languages\\ANTLRv3\\Generators\\Test\\Test.g:8:9: ')'
                {
                    DebugLocation(8, 9);
                    Match(')'); 

                }

                state.type = _type;
                state.channel = _channel;
            }
            finally
            {
                TraceOut("T__12", 2);
                LeaveRule("T__12", 2);
                LeaveRule_T__12();
            }
        }
        // $ANTLR end "T__12"

        partial void EnterRule_T__13();
        partial void LeaveRule_T__13();

        // $ANTLR start "T__13"
        [GrammarRule("T__13")]
        private void mT__13()
        {
            EnterRule_T__13();
            EnterRule("T__13", 3);
            TraceIn("T__13", 3);
            try
            {
                int _type = T__13;
                int _channel = DefaultTokenChannel;
                // C:\\Users\\exKAZUu\\Projects\\Code2Xml\\Code2Xml.Languages\\ANTLRv3\\Generators\\Test\\Test.g:9:7: ( '*' )
                DebugEnterAlt(1);
                // C:\\Users\\exKAZUu\\Projects\\Code2Xml\\Code2Xml.Languages\\ANTLRv3\\Generators\\Test\\Test.g:9:9: '*'
                {
                    DebugLocation(9, 9);
                    Match('*'); 

                }

                state.type = _type;
                state.channel = _channel;
            }
            finally
            {
                TraceOut("T__13", 3);
                LeaveRule("T__13", 3);
                LeaveRule_T__13();
            }
        }
        // $ANTLR end "T__13"

        partial void EnterRule_T__14();
        partial void LeaveRule_T__14();

        // $ANTLR start "T__14"
        [GrammarRule("T__14")]
        private void mT__14()
        {
            EnterRule_T__14();
            EnterRule("T__14", 4);
            TraceIn("T__14", 4);
            try
            {
                int _type = T__14;
                int _channel = DefaultTokenChannel;
                // C:\\Users\\exKAZUu\\Projects\\Code2Xml\\Code2Xml.Languages\\ANTLRv3\\Generators\\Test\\Test.g:10:7: ( '+' )
                DebugEnterAlt(1);
                // C:\\Users\\exKAZUu\\Projects\\Code2Xml\\Code2Xml.Languages\\ANTLRv3\\Generators\\Test\\Test.g:10:9: '+'
                {
                    DebugLocation(10, 9);
                    Match('+'); 

                }

                state.type = _type;
                state.channel = _channel;
            }
            finally
            {
                TraceOut("T__14", 4);
                LeaveRule("T__14", 4);
                LeaveRule_T__14();
            }
        }
        // $ANTLR end "T__14"

        partial void EnterRule_T__15();
        partial void LeaveRule_T__15();

        // $ANTLR start "T__15"
        [GrammarRule("T__15")]
        private void mT__15()
        {
            EnterRule_T__15();
            EnterRule("T__15", 5);
            TraceIn("T__15", 5);
            try
            {
                int _type = T__15;
                int _channel = DefaultTokenChannel;
                // C:\\Users\\exKAZUu\\Projects\\Code2Xml\\Code2Xml.Languages\\ANTLRv3\\Generators\\Test\\Test.g:11:7: ( '=' )
                DebugEnterAlt(1);
                // C:\\Users\\exKAZUu\\Projects\\Code2Xml\\Code2Xml.Languages\\ANTLRv3\\Generators\\Test\\Test.g:11:9: '='
                {
                    DebugLocation(11, 9);
                    Match('='); 

                }

                state.type = _type;
                state.channel = _channel;
            }
            finally
            {
                TraceOut("T__15", 5);
                LeaveRule("T__15", 5);
                LeaveRule_T__15();
            }
        }
        // $ANTLR end "T__15"

        partial void EnterRule_Identifier();
        partial void LeaveRule_Identifier();

        // $ANTLR start "Identifier"
        [GrammarRule("Identifier")]
        private void mIdentifier()
        {
            EnterRule_Identifier();
            EnterRule("Identifier", 6);
            TraceIn("Identifier", 6);
            try
            {
                int _type = Identifier;
                int _channel = DefaultTokenChannel;
                // C:\\Users\\exKAZUu\\Projects\\Code2Xml\\Code2Xml.Languages\\ANTLRv3\\Generators\\Test\\Test.g:36:2: ( IdentifierStart ( IdentifierPart )* )
                DebugEnterAlt(1);
                // C:\\Users\\exKAZUu\\Projects\\Code2Xml\\Code2Xml.Languages\\ANTLRv3\\Generators\\Test\\Test.g:36:4: IdentifierStart ( IdentifierPart )*
                {
                    DebugLocation(36, 4);
                    mIdentifierStart(); 
                    DebugLocation(36, 20);
                    // C:\\Users\\exKAZUu\\Projects\\Code2Xml\\Code2Xml.Languages\\ANTLRv3\\Generators\\Test\\Test.g:36:20: ( IdentifierPart )*
                    try { DebugEnterSubRule(1);
                        while (true)
                        {
                            int alt1=2;
                            try { DebugEnterDecision(1, false);
                                int LA1_1 = input.LA(1);

                                if (((LA1_1>='0' && LA1_1<='9')||(LA1_1>='A' && LA1_1<='Z')||LA1_1=='_'||(LA1_1>='a' && LA1_1<='z')))
                                {
                                    alt1 = 1;
                                }


                            } finally { DebugExitDecision(1); }
                            switch ( alt1 )
                            {
                            case 1:
                                DebugEnterAlt(1);
                                // C:\\Users\\exKAZUu\\Projects\\Code2Xml\\Code2Xml.Languages\\ANTLRv3\\Generators\\Test\\Test.g:
                            {
                                DebugLocation(36, 20);
                                input.Consume();


                            }
                                break;

                            default:
                                goto loop1;
                            }
                        }

                        loop1:
                        ;

                    } finally { DebugExitSubRule(1); }


                }

                state.type = _type;
                state.channel = _channel;
            }
            finally
            {
                TraceOut("Identifier", 6);
                LeaveRule("Identifier", 6);
                LeaveRule_Identifier();
            }
        }
        // $ANTLR end "Identifier"

        partial void EnterRule_IdentifierStart();
        partial void LeaveRule_IdentifierStart();

        // $ANTLR start "IdentifierStart"
        [GrammarRule("IdentifierStart")]
        private void mIdentifierStart()
        {
            EnterRule_IdentifierStart();
            EnterRule("IdentifierStart", 7);
            TraceIn("IdentifierStart", 7);
            try
            {
                // C:\\Users\\exKAZUu\\Projects\\Code2Xml\\Code2Xml.Languages\\ANTLRv3\\Generators\\Test\\Test.g:42:2: ( '@' | '_' | 'A' .. 'Z' | 'a' .. 'z' )
                DebugEnterAlt(1);
                // C:\\Users\\exKAZUu\\Projects\\Code2Xml\\Code2Xml.Languages\\ANTLRv3\\Generators\\Test\\Test.g:
                {
                    DebugLocation(42, 2);
                    if ((input.LA(1)>='@' && input.LA(1)<='Z')||input.LA(1)=='_'||(input.LA(1)>='a' && input.LA(1)<='z'))
                    {
                        input.Consume();
                    }
                    else
                    {
                        MismatchedSetException mse = new MismatchedSetException(null,input);
                        DebugRecognitionException(mse);
                        Recover(mse);
                        throw mse;
                    }


                }

            }
            finally
            {
                TraceOut("IdentifierStart", 7);
                LeaveRule("IdentifierStart", 7);
                LeaveRule_IdentifierStart();
            }
        }
        // $ANTLR end "IdentifierStart"

        partial void EnterRule_IdentifierPart();
        partial void LeaveRule_IdentifierPart();

        // $ANTLR start "IdentifierPart"
        [GrammarRule("IdentifierPart")]
        private void mIdentifierPart()
        {
            EnterRule_IdentifierPart();
            EnterRule("IdentifierPart", 8);
            TraceIn("IdentifierPart", 8);
            try
            {
                // C:\\Users\\exKAZUu\\Projects\\Code2Xml\\Code2Xml.Languages\\ANTLRv3\\Generators\\Test\\Test.g:47:2: ( 'A' .. 'Z' | 'a' .. 'z' | '0' .. '9' | '_' )
                DebugEnterAlt(1);
                // C:\\Users\\exKAZUu\\Projects\\Code2Xml\\Code2Xml.Languages\\ANTLRv3\\Generators\\Test\\Test.g:
                {
                    DebugLocation(47, 2);
                    if ((input.LA(1)>='0' && input.LA(1)<='9')||(input.LA(1)>='A' && input.LA(1)<='Z')||input.LA(1)=='_'||(input.LA(1)>='a' && input.LA(1)<='z'))
                    {
                        input.Consume();
                    }
                    else
                    {
                        MismatchedSetException mse = new MismatchedSetException(null,input);
                        DebugRecognitionException(mse);
                        Recover(mse);
                        throw mse;
                    }


                }

            }
            finally
            {
                TraceOut("IdentifierPart", 8);
                LeaveRule("IdentifierPart", 8);
                LeaveRule_IdentifierPart();
            }
        }
        // $ANTLR end "IdentifierPart"

        partial void EnterRule_IntegerLiteral();
        partial void LeaveRule_IntegerLiteral();

        // $ANTLR start "IntegerLiteral"
        [GrammarRule("IntegerLiteral")]
        private void mIntegerLiteral()
        {
            EnterRule_IntegerLiteral();
            EnterRule("IntegerLiteral", 9);
            TraceIn("IntegerLiteral", 9);
            try
            {
                int _type = IntegerLiteral;
                int _channel = DefaultTokenChannel;
                // C:\\Users\\exKAZUu\\Projects\\Code2Xml\\Code2Xml.Languages\\ANTLRv3\\Generators\\Test\\Test.g:49:15: ( Decimal_digits )
                DebugEnterAlt(1);
                // C:\\Users\\exKAZUu\\Projects\\Code2Xml\\Code2Xml.Languages\\ANTLRv3\\Generators\\Test\\Test.g:50:2: Decimal_digits
                {
                    DebugLocation(50, 2);
                    mDecimal_digits(); 

                }

                state.type = _type;
                state.channel = _channel;
            }
            finally
            {
                TraceOut("IntegerLiteral", 9);
                LeaveRule("IntegerLiteral", 9);
                LeaveRule_IntegerLiteral();
            }
        }
        // $ANTLR end "IntegerLiteral"

        partial void EnterRule_Decimal_digits();
        partial void LeaveRule_Decimal_digits();

        // $ANTLR start "Decimal_digits"
        [GrammarRule("Decimal_digits")]
        private void mDecimal_digits()
        {
            EnterRule_Decimal_digits();
            EnterRule("Decimal_digits", 10);
            TraceIn("Decimal_digits", 10);
            try
            {
                // C:\\Users\\exKAZUu\\Projects\\Code2Xml\\Code2Xml.Languages\\ANTLRv3\\Generators\\Test\\Test.g:55:15: ( ( DECIMAL_DIGIT )+ )
                DebugEnterAlt(1);
                // C:\\Users\\exKAZUu\\Projects\\Code2Xml\\Code2Xml.Languages\\ANTLRv3\\Generators\\Test\\Test.g:56:2: ( DECIMAL_DIGIT )+
                {
                    DebugLocation(56, 2);
                    // C:\\Users\\exKAZUu\\Projects\\Code2Xml\\Code2Xml.Languages\\ANTLRv3\\Generators\\Test\\Test.g:56:2: ( DECIMAL_DIGIT )+
                    int cnt2=0;
                    try { DebugEnterSubRule(2);
                        while (true)
                        {
                            int alt2=2;
                            try { DebugEnterDecision(2, false);
                                int LA2_1 = input.LA(1);

                                if (((LA2_1>='0' && LA2_1<='9')))
                                {
                                    alt2 = 1;
                                }


                            } finally { DebugExitDecision(2); }
                            switch (alt2)
                            {
                            case 1:
                                DebugEnterAlt(1);
                                // C:\\Users\\exKAZUu\\Projects\\Code2Xml\\Code2Xml.Languages\\ANTLRv3\\Generators\\Test\\Test.g:
                            {
                                DebugLocation(56, 2);
                                input.Consume();


                            }
                                break;

                            default:
                                if (cnt2 >= 1)
                                    goto loop2;

                                EarlyExitException eee2 = new EarlyExitException( 2, input );
                                DebugRecognitionException(eee2);
                                throw eee2;
                            }
                            cnt2++;
                        }
                        loop2:
                        ;

                    } finally { DebugExitSubRule(2); }


                }

            }
            finally
            {
                TraceOut("Decimal_digits", 10);
                LeaveRule("Decimal_digits", 10);
                LeaveRule_Decimal_digits();
            }
        }
        // $ANTLR end "Decimal_digits"

        partial void EnterRule_DECIMAL_DIGIT();
        partial void LeaveRule_DECIMAL_DIGIT();

        // $ANTLR start "DECIMAL_DIGIT"
        [GrammarRule("DECIMAL_DIGIT")]
        private void mDECIMAL_DIGIT()
        {
            EnterRule_DECIMAL_DIGIT();
            EnterRule("DECIMAL_DIGIT", 11);
            TraceIn("DECIMAL_DIGIT", 11);
            try
            {
                // C:\\Users\\exKAZUu\\Projects\\Code2Xml\\Code2Xml.Languages\\ANTLRv3\\Generators\\Test\\Test.g:60:14: ( '0' .. '9' )
                DebugEnterAlt(1);
                // C:\\Users\\exKAZUu\\Projects\\Code2Xml\\Code2Xml.Languages\\ANTLRv3\\Generators\\Test\\Test.g:
                {
                    DebugLocation(60, 14);
                    if ((input.LA(1)>='0' && input.LA(1)<='9'))
                    {
                        input.Consume();
                    }
                    else
                    {
                        MismatchedSetException mse = new MismatchedSetException(null,input);
                        DebugRecognitionException(mse);
                        Recover(mse);
                        throw mse;
                    }


                }

            }
            finally
            {
                TraceOut("DECIMAL_DIGIT", 11);
                LeaveRule("DECIMAL_DIGIT", 11);
                LeaveRule_DECIMAL_DIGIT();
            }
        }
        // $ANTLR end "DECIMAL_DIGIT"

        partial void EnterRule_WS();
        partial void LeaveRule_WS();

        // $ANTLR start "WS"
        [GrammarRule("WS")]
        private void mWS()
        {
            EnterRule_WS();
            EnterRule("WS", 12);
            TraceIn("WS", 12);
            try
            {
                int _type = WS;
                int _channel = DefaultTokenChannel;
                // C:\\Users\\exKAZUu\\Projects\\Code2Xml\\Code2Xml.Languages\\ANTLRv3\\Generators\\Test\\Test.g:63:3: ( ( ' ' | '\\r' | '\\t' | '\\n' ) )
                DebugEnterAlt(1);
                // C:\\Users\\exKAZUu\\Projects\\Code2Xml\\Code2Xml.Languages\\ANTLRv3\\Generators\\Test\\Test.g:64:5: ( ' ' | '\\r' | '\\t' | '\\n' )
                {
                    DebugLocation(64, 5);
                    if ((input.LA(1)>='\t' && input.LA(1)<='\n')||input.LA(1)=='\r'||input.LA(1)==' ')
                    {
                        input.Consume();
                    }
                    else
                    {
                        MismatchedSetException mse = new MismatchedSetException(null,input);
                        DebugRecognitionException(mse);
                        Recover(mse);
                        throw mse;
                    }

                    DebugLocation(65, 5);
                    _channel=Hidden; 

                }

                state.type = _type;
                state.channel = _channel;
            }
            finally
            {
                TraceOut("WS", 12);
                LeaveRule("WS", 12);
                LeaveRule_WS();
            }
        }
        // $ANTLR end "WS"

        public override void mTokens()
        {
            // C:\\Users\\exKAZUu\\Projects\\Code2Xml\\Code2Xml.Languages\\ANTLRv3\\Generators\\Test\\Test.g:1:8: ( T__11 | T__12 | T__13 | T__14 | T__15 | Identifier | IntegerLiteral | WS )
            int alt3=8;
            try { DebugEnterDecision(3, false);
                switch (input.LA(1))
                {
                case '(':
                {
                    alt3 = 1;
                }
                    break;
                case ')':
                {
                    alt3 = 2;
                }
                    break;
                case '*':
                {
                    alt3 = 3;
                }
                    break;
                case '+':
                {
                    alt3 = 4;
                }
                    break;
                case '=':
                {
                    alt3 = 5;
                }
                    break;
                case '@':
                case 'A':
                case 'B':
                case 'C':
                case 'D':
                case 'E':
                case 'F':
                case 'G':
                case 'H':
                case 'I':
                case 'J':
                case 'K':
                case 'L':
                case 'M':
                case 'N':
                case 'O':
                case 'P':
                case 'Q':
                case 'R':
                case 'S':
                case 'T':
                case 'U':
                case 'V':
                case 'W':
                case 'X':
                case 'Y':
                case 'Z':
                case '_':
                case 'a':
                case 'b':
                case 'c':
                case 'd':
                case 'e':
                case 'f':
                case 'g':
                case 'h':
                case 'i':
                case 'j':
                case 'k':
                case 'l':
                case 'm':
                case 'n':
                case 'o':
                case 'p':
                case 'q':
                case 'r':
                case 's':
                case 't':
                case 'u':
                case 'v':
                case 'w':
                case 'x':
                case 'y':
                case 'z':
                {
                    alt3 = 6;
                }
                    break;
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                {
                    alt3 = 7;
                }
                    break;
                case '\t':
                case '\n':
                case '\r':
                case ' ':
                {
                    alt3 = 8;
                }
                    break;
                default:
                {
                    NoViableAltException nvae = new NoViableAltException("", 3, 0, input, 1);
                    DebugRecognitionException(nvae);
                    throw nvae;
                }
                }

            } finally { DebugExitDecision(3); }
            switch (alt3)
            {
            case 1:
                DebugEnterAlt(1);
                // C:\\Users\\exKAZUu\\Projects\\Code2Xml\\Code2Xml.Languages\\ANTLRv3\\Generators\\Test\\Test.g:1:10: T__11
            {
                DebugLocation(1, 10);
                mT__11(); 

            }
                break;
            case 2:
                DebugEnterAlt(2);
                // C:\\Users\\exKAZUu\\Projects\\Code2Xml\\Code2Xml.Languages\\ANTLRv3\\Generators\\Test\\Test.g:1:16: T__12
            {
                DebugLocation(1, 16);
                mT__12(); 

            }
                break;
            case 3:
                DebugEnterAlt(3);
                // C:\\Users\\exKAZUu\\Projects\\Code2Xml\\Code2Xml.Languages\\ANTLRv3\\Generators\\Test\\Test.g:1:22: T__13
            {
                DebugLocation(1, 22);
                mT__13(); 

            }
                break;
            case 4:
                DebugEnterAlt(4);
                // C:\\Users\\exKAZUu\\Projects\\Code2Xml\\Code2Xml.Languages\\ANTLRv3\\Generators\\Test\\Test.g:1:28: T__14
            {
                DebugLocation(1, 28);
                mT__14(); 

            }
                break;
            case 5:
                DebugEnterAlt(5);
                // C:\\Users\\exKAZUu\\Projects\\Code2Xml\\Code2Xml.Languages\\ANTLRv3\\Generators\\Test\\Test.g:1:34: T__15
            {
                DebugLocation(1, 34);
                mT__15(); 

            }
                break;
            case 6:
                DebugEnterAlt(6);
                // C:\\Users\\exKAZUu\\Projects\\Code2Xml\\Code2Xml.Languages\\ANTLRv3\\Generators\\Test\\Test.g:1:40: Identifier
            {
                DebugLocation(1, 40);
                mIdentifier(); 

            }
                break;
            case 7:
                DebugEnterAlt(7);
                // C:\\Users\\exKAZUu\\Projects\\Code2Xml\\Code2Xml.Languages\\ANTLRv3\\Generators\\Test\\Test.g:1:51: IntegerLiteral
            {
                DebugLocation(1, 51);
                mIntegerLiteral(); 

            }
                break;
            case 8:
                DebugEnterAlt(8);
                // C:\\Users\\exKAZUu\\Projects\\Code2Xml\\Code2Xml.Languages\\ANTLRv3\\Generators\\Test\\Test.g:1:66: WS
            {
                DebugLocation(1, 66);
                mWS(); 

            }
                break;

            }

        }


        #region DFA

        protected override void InitDFAs()
        {
            base.InitDFAs();
        }

        #endregion

    }
}
