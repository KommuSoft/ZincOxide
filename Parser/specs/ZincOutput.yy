/*
 *  Process with > gppg /nolines ZincOutput.yy
 */

%output=../ZincOutputParser.cs 
%namespace ZincOxide.Parser
%parsertype ZincOutputParser

%tokentype OutputToken

%visibility public

%partial 

%sharetokens

%start output

%YYSTYPE StateStructure
%YYLTYPE LexSpan

%token SOLCOM NOSOL NOMSL NOBSL SCOM SMIU SSSC SLSO WARN SICP LINE NLN TWSP FRSP OTHER

%%
output
    : solutionList outcome completeness warnings freeText EOF           {}
    ;

solutionList
    :                                                                   {}
    | solution solutionList                                             {}
    ;

solution
    : SOLCOM solutionText NLN                                           {}
    | SOLCOM solutionText                                               {}
    ;

outcome
    : NOSOL                                                             {}
    | NOMSL                                                             {}
    | NOBSL                                                             {}
    ;

completeness
    : complete                                                          {}
    | incomplete                                                        {}
    ;

complete
    : SCOM completenessMsg NLN                                          {}
    ;

completenessMsg
    : SMIU                                                              {}
    | SSSC                                                              {}
    | SLSO                                                              {}
    ;

incomplete
    : SICP messageList                                                  {}
    ;

warnings
    : WARN messageList                                                  {}
    ;

messageList
    :                                                                  {}
    | message messageList                                              {}
    ;

message
    : TWSP LINE  fsline                                                {}
    ;

fsline
    :                                                                  {}
    | FRSP LINE fsline                                                 {}
    ;

%%