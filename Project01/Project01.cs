using System.Net.Sockets;
using System;
using System.Reflection;
using System.Security.Cryptography;
/// <summary> 
/// Name: Chris Pate
/// Email: cpate6@stumail.northeaststate.edu
/// Purpose: Project01
/// </summary>
namespace CISP1010
{
    /// <summary>
    /// Project01 - Welcome to the slayer version of Rock Paper Scissors.
    /// </summary>
    internal class Project01
    {
        /// <summary>
        /// The main method is the entry point for the program
        /// </summary>
        /// <param name="args">string array for command line parameters</param>
        static void Main(string[] args)
        {
         
            #region "Window Settings"
            // Set the window height and width
            Console.SetWindowSize(170, 44);

            // Set the window to a fixed position
#pragma warning disable CA1416 // Validate platform compatibility
            Console.SetWindowPosition(0, 0);
#pragma warning restore CA1416 // Validate platform compatibility
            #endregion

            #region "Startup Screen"
            PrintSmallHeader();
            PrintLargeWelcomeMessage();
            Thread.Sleep(4000);
            Console.Clear();
            #endregion

            #region "Console Setup"
            // Base background colors for the players
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            #endregion

            #region "Menu"
            PrintSmallHeader();
            Console.WriteLine();

            ShowMenu();
            #endregion

            #region "Utility Methods"

            // Prompt user for char
            static char PrompForChar(string messagePrompt)
            {
                Console.ForegroundColor = ConsoleColor.White;
                char choice = Convert.ToChar(Console.ReadKey(true).KeyChar);
                return choice;
            } // end of PrompForChar
            
            // Prompt user for char hidden
            static char PromptForCharHidden(string messagePrompt)
            {
                Console.ForegroundColor = ConsoleColor.White;
                char selection;
                //do
                //{
                //    HiddenSelection();
                //}
                //while (selection != '1' || selection != '2' || selection != '3');
                Console.WriteLine(messagePrompt);
                Console.CursorVisible = false;
                selection = Console.ReadKey(true).KeyChar;
                return (char)selection;
            } // end of PrompForCharHidden

            // Prompt user for string
            static string PromptForString(string messagePrompt)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(messagePrompt);
                return messagePrompt;

            } // end of PromptForString

            // Prompt for user to press any key
            static void PressAnyKey()
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            } // end of PressAnyKey

            #endregion

            #region "Game Logic"
            // Play again?
            static void PlayAgain(char playAgain)
            {
                byte exit;
                if (playAgain == 'y')
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Clear();
                    ShowMenu();
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Clear();
                    ExitOption();
                }
            }

            // Calculate which player wins
            static byte CalculateWinner(char playerOneChoice, char playerTwoChoice)
            {
                 byte results = 0;
                //Freddy Krueger[1], Michael Myers[2], Leatherface[3]
                //Console.WriteLine("Freddy Krueger beats Michael Myers");
                //Console.WriteLine("Michael Myers beats Leatherface");
                //Console.WriteLine("Leatherface beats Freddy Krueger");
                if (playerOneChoice == '1' && playerTwoChoice == '2')
                {
                    return results = Convert.ToByte('1');
                }
                else if (playerOneChoice == '1' && playerTwoChoice == '3')
                {
                    return results = Convert.ToByte('2');
                }
                else if (playerOneChoice == '2' && playerTwoChoice == '3')
                {
                    return results = Convert.ToByte('1');
                }
                else if (playerOneChoice == '2' && playerTwoChoice == '1')
                {
                    return results = Convert.ToByte('2');                
                }
                else if (playerOneChoice == '3' && playerTwoChoice == '1')
                {
                    return results = Convert.ToByte('1');
                }
                else if (playerOneChoice == '3' && playerTwoChoice == '2')
                {
                    return results = Convert.ToByte('2');
                }
                else if (playerOneChoice == playerTwoChoice)
                {
                    return results = Convert.ToByte('0');                 
                }
                return results;

            }// end of CalculateWinner

            // Calculate which weapon will show up on the screen
            static byte CalculateWinnerWeapon(char playerOneChoice, char playerTwoChoice)
            {
                byte weapon = 0;
                //Freddy Krueger[1], Michael Myers[2], Leatherface[3]
                //Console.WriteLine("Freddy Krueger beats Michael Myers");
                //Console.WriteLine("Michael Myers beats Leatherface");
                //Console.WriteLine("Leatherface beats Freddy Krueger");
                if (playerOneChoice == '1' && playerTwoChoice == '2')
                {
                    return weapon = Convert.ToByte('1');
                }
                else if (playerOneChoice == '1' && playerTwoChoice == '3')
                {
                    return weapon = Convert.ToByte('3');
                }
                else if (playerOneChoice == '2' && playerTwoChoice == '3')
                {
                    return weapon = Convert.ToByte('2');
                }
                else if (playerOneChoice == '2' && playerTwoChoice == '1')
                {
                    return weapon = Convert.ToByte('1');
                }
                else if (playerOneChoice == '3' && playerTwoChoice == '1')
                {
                    return weapon = Convert.ToByte('3');
                }
                else if (playerOneChoice == '3' && playerTwoChoice == '2')
                {
                    return weapon = Convert.ToByte('2');
                }
                else if (playerOneChoice == playerTwoChoice)
                {
                    return weapon = Convert.ToByte('0');
                }
                return weapon;

            }// end of CalculateWinner

            // Announce winner right before weapon
            static string AnnounceWinner(byte results, char playerOneChoice, char playerTwoChoice)
            {
                string winner;
                if (results == '0')
                {
                    winner ="                                                                            The game ends in a tie!";
                    return winner.ToUpper();
                }
                else if (results == '1')
                {
                    string playerOneChoiceString = ConvertChoiceToName(playerOneChoice);
                    winner = $"                                                                         {playerOneChoiceString} wins!";
                    return winner.ToUpper();
                }
                else if (results == '2')
                {
                    string playerTwoChoiceString = ConvertChoiceToName(playerTwoChoice);
                    winner = $"                                                                         {playerTwoChoiceString} wins!";
                    return winner.ToUpper();
                }
                else
                {
                    winner = "Error";
                }
                return winner;
                

            }

            // Print the player names and their choices
            static void PrintResults(string playerOneName, char playerOneChoice, string playerTwoName, char playerTwoChoice)
            {
                string playerOneChoiceString = ConvertChoiceToName(playerOneChoice);
                string playerTwoChoiceString = ConvertChoiceToName(playerTwoChoice);
                Console.WriteLine($"                                                 {playerOneName} selected {playerOneChoiceString} and {playerTwoName} selected {playerTwoChoiceString}.");
            }

            // Take the user input and convert it into the name they selected.
            static string ConvertChoiceToName(char playerChoice)
            {
                string playerChoiceString;
                playerChoiceString = " ";
                //Freddy Krueger[1], Michael Myers[2], Leatherface[3]
                if (playerChoice == '1')
                {
                    playerChoiceString = "Freddy Krueger";
                } else if (playerChoice == '2')
                {
                    playerChoiceString = "Michael Myers";
                } else if (playerChoice == '3')
                {
                    playerChoiceString = "Leatherface";
                }
                return playerChoiceString;
            }// end of ConvertChoiceToName

            // method to just print the names who are battling
            static void Versus(string playerOneName, string playerTwoName)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"                                                                      {playerOneName} vs. {playerTwoName}                     ");
            
            }
            #endregion

            #region "ASCII"

            // Menu in ASCII
            static void MenuBanner()
            {
                Console.WriteLine("                                                                 #     #                                   ");
                Console.WriteLine("                                                                 ##   ## ###### #    # #    #            ");
                Console.WriteLine("                                                                 # # # # #      ##   # #    #         ");
                Console.WriteLine("                                                                 #  #  # #####  # #  # #    #          ");
                Console.WriteLine("                                                                 #     # #      #  # # #    #          ");
                Console.WriteLine("                                                                 #     # #      #   ## #    #          ");
                Console.WriteLine("                                                                 #     # ###### #    #  ####              ");
            }

            // create separator
            static void Seperator()
            {
                Console.ForegroundColor= ConsoleColor.DarkRed;
                Console.WriteLine("                                                   #############################################################");
            }

            // Create battle ASCII
            static void Battle()
            {
                Console.WriteLine("              #       ####### #######    ####### #     # #######    ######     #    ####### ####### #       #######    ######  #######  #####  ### #     #  ### ###");
                Console.WriteLine("              #       #          #          #    #     # #          #     #   # #      #       #    #       #          #     # #       #     #  #  ##    #  ### ###");
                Console.WriteLine("              #       #          #          #    #     # #          #     #  #   #     #       #    #       #          #     # #       #        #  # #   #  ### ###");
                Console.WriteLine("              #       #####      #          #    ####### #####      ######  #     #    #       #    #       #####      ######  #####   #  ####  #  #  #  #   #   # ");
                Console.WriteLine("              #       #          #          #    #     # #          #     # #######    #       #    #       #          #     # #       #     #  #  #   # #         ");
                Console.WriteLine("              #       #          #          #    #     # #          #     # #     #    #       #    #       #          #     # #       #     #  #  #    ##  ### ###");
                Console.WriteLine("              ####### #######    #          #    #     # #######    ######  #     #    #       #    ####### #######    ######  #######  #####  ### #     #  ### ###"); 
            }

            // Single player ASCII
            static void SinglePlayer()
            {
                Console.WriteLine("                                          #####                                   ######                                    ");
                Console.WriteLine("                                         #     # # #    #  ####  #      ######    #     # #        ##   #   # ###### #####  ");
                Console.WriteLine("                                         #       # ##   # #    # #      #         #     # #       #  #   # #  #      #    # ");
                Console.WriteLine("                                         #####   # # #  # #      #      #####     ######  #      #    #   #   #####  #    # ");
                Console.WriteLine("                                              #  # #  # # #  ### #      #         #       #      ######   #   #      #####  ");
                Console.WriteLine("                                        #     #  # #    # #    # #      #         #       #      #    #   #   #      #   #  ");
                Console.WriteLine("                                         #####   # #    #  ####  ###### ######    #       ###### #    #   #   ###### #    # ");
                Console.WriteLine();
                Seperator();
                Console.WriteLine();
            }

            // TWO player ASCII
            static void TwoPlayerBattle()
            {
                Console.WriteLine("                     #####     ######                                       ######                                      ######                             ");
                Console.WriteLine("                          #    #     # #        #    #   # ###### #####     #     #   ##   ##### ##### #      ######    #     #  ####  #   #   ##   #      ");
                Console.WriteLine("                          #    #     # #       #  #   # #  #      #    #    #     #  #  #    #     #   #      #         #     # #    #  # #   #  #  #      ");
                Console.WriteLine("                     #####     ######  #      #    #   #   #####  #    #    ######  #    #   #     #   #      #####     ######  #    #   #   #    # #      ");
                Console.WriteLine("                    #          #       #      ######   #   #      #####     #     # ######   #     #   #      #         #   #   #    #   #   ###### #      ");
                Console.WriteLine("                    #          #       #      #    #   #   #      #   #     #     # #    #   #     #   #      #         #    #  #    #   #   #    # #      ");
                Console.WriteLine("                    #######    #       ###### #    #   #   ###### #    #    ######  #    #   #     #   ###### ######    #     #  ####    #   #    # ###### ");
                Console.WriteLine();
                Seperator();
                Console.WriteLine();
            }

            // Title screen
            static void PrintLargeWelcomeMessage()
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
                //Console.WriteLine("                                                     WELCOME TO THE SLAYER VERSION OF PAPER, ROCK, SCISSORS!!                                                   ");
                Console.WriteLine("                                                                     Created by: Chris Pate                                                                     ");
                Console.WriteLine();
                Console.WriteLine("@@@@@@@&&&@&&&&&&&&&&&&&&&&&&@&&&&&&##&#####&#########################BB##BBB###&##&########BBBBBBBB#B#BB###BBBB##B####B########BGBBBBB#########################");
                Console.WriteLine("@@@&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&################&&##BBBBB#BBB#B##B#BB#BBBB###&#########BBBBBBBBBBB#BBB#BBBBBBBBB#B#####BGPPP5PP55BPGGGGBGGB#BBBG####BBBBB###");
                Console.WriteLine("&&&&&&&&&&&&&&&#&##B#BBBBBBPG#&&&&&&##B#BBBBBB#BBBB###BBBBGGBGBBBBBBBBBGGBBBGGGGBBB##BBBB#BBBGGGBBBBBBBBBBBBBBBGBBBBBB###&GYYYJ?Y5555PYYJJYY55Y5PYG55BBBBBBBB###");
                Console.WriteLine("&&&&&&&&&&&&&#GGPPPPBGGPPP55YPB#BBB#&#BBBBBBBBBBBBBBBBGGGGGGGGBBBBBBGGGGBGGGB##&&&&@@@&#BGGGGGBBBBBBBBBBBBBBBBGGGBBBBBBB&#JPBPPG#&#&&&#BBBGPG###BG5PPJGBBBBBGGGB");
                Console.WriteLine("&&&&&&&###BG55PGB#&@@@@&#BGGBBP5B#B###BBBBBBBBBBBB#BBBGGGGGGGGBGGGGGGGGGB#&@@@&#BBBBB#&##BPGGGBGGGGBBBGBGBBGBGGGGBBBGGPP55P&@&#&@##@@@@@@@@@@@@@@@&#5?PBG5PGPJYP");
                Console.WriteLine("&&&&#BGPPYJ??JY5PB&@@@@@@@&&@&BPPPGB##BBGGGBBGBBBBBBBGPPGGGGGBBBGGPB#&&@@@@&#BBBBBBBBBBB##BGGGGGGGGGGGGGGGGGGGGPPP55555PGB&@@@@@@@@@@@@@@@@@@@@@@@@#YYYJYGBGY5PG");
                Console.WriteLine("&&&&###BBPYY5GB&@@@@@@@@@@@@@@@&&BG55PGBGGBBBBBGGGGGGGGGGGGGGB#BGGB&&&&&&#BBBBB######BBBBB##PGGGGGGPPGGGGGGGGP5JJY5PB&@@@@@@@@@@&#&@&@@@@@@@@@@@@@@@BBBG&@GPGG5Y");
                Console.WriteLine("&&&#&&#B5YP#@@@@@@@@@@@@@@@@@@@@@@@#GPPPGGGBBBGGGGPPGGPGGPGGGGGPB##&&&&#####&&&&&&&&&#BBBBBBBYPPPPPPPPGBGGGG5P5JJYB#&@@@@@@@@&@@#G#&##&@@&##&&#&@@@@@@@@@@#G55GG");
                Console.WriteLine("&&&&&#BGP#@@@@@@@@@@@@@@&&&@@@@@@@@@@@@#J5GGPGGPGGGPPGPPGGGPP5Y5&&@@@@@@@@@@@@@@@@@@@@@&&##B#Y5PPPPPPPPPPGPYJYY?5G&@@@@@@&BGG5#&#&&PGBGBG5J7YG#&@@@@@@@@@@&PGP5G");
                Console.WriteLine("&###BGY5&@@@@@@@@&BGPP5YJ??JY5G#&@@@@@@#YY5PGPPPPPPPPPPPPPPPGB#&@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&&&&#BBGGPPPPPJ5PGPG&@@@@@@#J?77Y5PP&G?JJ5PP5YJ5PYPGG&&@@@@@@B55P5P");
                Console.WriteLine("&##G5P#@@@@@@&G5?7!!!!777!!!!!!7?JPB&@@&G5JYPPPPPPPPPPPGGGB&@@@@@@@@@@@@@@@@@@@@&&@@@@@@@@@@@@@@@@@@@@@&#GPYPG#@@@@@@@@P777JY??7JY5?777?J??JYJ55YYPG&@@@@@#BGPY5");
                Console.WriteLine("#BP5G&@@@@@#5?!!!!777777777777777!!7JG&@#BGYPPPPPPPPPG#&@@@@@@@@@@@@@@&&#BBBBBBBBGGBBB&@@@@@@@@@@@@@@@@@@@@B5PB#@@@@@@P77JJJ?77777??77777??77?775YY5B@@@@@@&#B5Y");
                Console.WriteLine("P55P#@@@@&G?!!7777777777777777777777775&@@@PPGPPPPG#&@@@@@@@@@@@@@@BBBG5YYYYYYYYYYYYYPGPGGGB@@@@@@@@@@@@@@@@@GPB&@@@@#?JYY?777??7???????YYJJJ?7JJ?PGP#@@@@@@&BGY");
                Console.WriteLine("BPP&@@@@&PJ!!777777777777777777777777!7G@@@5YPGPG#@@@@@@@@@@@@@#B@BPPGYJJJJJJJJ???J?J???55555P#@@@@@@@@@@@@@@@&@@@@@&JJPJ???777????7?JYYYY555YY555?GPG@@@@@@#&GY");
                Console.WriteLine("PPG&@@@#G577777777777777777777!!!!!!7!75&@@PJ5PB@@@@@@@@@@@@@@@5G#GGP5JJ5GBB#BG5JJ5YJJJJJJJJJ?P&@@@@@@@@@@@@@@@@@@@@P?J??5Y?JJJYYJJ??7????JJY55JJ7?P&B@@@@@@BGGY");
                Console.WriteLine("Y5B&@@@GP5?J55YJYYYP5?7777!7J55YJJ7777!JB@@@BP5@@@@@@@@@@@@@@@#JPGGPGY?G#PPPY5&&G5YJJY5GBBBGPYJG@@@@@@@@@@@@@@@#5G#GYJ777J5PB&&@@&#P5J??????JY?77?JG@@@@@@@@BYJP");
                Console.WriteLine("PB#@@@&P5555PPPPBBB#&&57!7?Y#@&#BBP?7777J&@&B5Y@@@@@@@@@@@@@@@BJPBGPYJYPP5555YGBPYJ?J5PG555##GYG@@@@@@@@@@@@@@@B??JJYY7777JP&@@@@@BP5YY55GGGBG5JY55B@@@@@@@#5Y5P");
                Console.WriteLine("YG&@@@#555555G&@@@@@&#BY7!75#@@@@@@B??777B@@PJY&@@@@@@@@@@&&&&BJ5G5J5YJJJJ55YJ?JYY?JP5Y5YYJ555JP@@@@@@@@@@@@@@@P?77YY?7?J?7JPGBBGPYYJ7?55P#@@@@#555G@@@@@@#YYPPP");
                Console.WriteLine("YG#&@B?Y55555B&&&&#G5J7Y7!!J?P&&&@@&G5?77P&@PJYB@@@@@@@#PGPPPG#YYPY5Y?YY??Y?JY5YJJJJYY5YYYYJ?Y55@@@@@@@@@@@@@@BY77?5Y77JPY77JYYYJYJ??77J5P#@@@@&G55G&@@@@&P?5PPP");
                Console.WriteLine("JPB@#BB5555577?YYYJ?77JY77!777JY555?777!?PP&B5JG@@@@@@@#YYBPBP#5JPJ5PJ555JYJPB55YJJ77JJYYYY5J?Y5@@@@@@@@@@@@@@#PJ7?PJ7775Y?????JYYJJJ?JY555GB#G5555P##B#&&PJ5GPP");
                Console.WriteLine("J5#&GB&P555557777777JYG##BP577!!!!!!!!7!7BG5BJJY&@@@@@@#YP5YBPGG?GJYGYY5PJYYPBB##5?7JPGPPPB5YY5YB@@@@@@@@@@@@&##GY5GYJ??5P55Y55J5BBPPBBPPB5JJY5555?P&P5JYG5J5PPP");
                Console.WriteLine("YJB#5PGJ55555GY77?5G5B@@@@@@B?77!!!!!!77?GGJBJ55G@@@@@@&PPPY&#GG?5PY5JP55??JYY5PB#BGGG5YGPP?YPP5GB@@@@@@@@@@GYBGBPGP5PY555GPPPPPPPPB&@@&&#57Y5555YY&@#5?JG5Y5PPP");
                Console.WriteLine("Y?Y#?J5J55555PB###GJ75P5GBJYG?JJ7!!!!?5??5?YGJ5P5B@@@@@@@GPYYB#BJJGYYYGYJJ?YB#BBPBB##B5J5Y5JYYPBPG@@@@@@@@@GJJY5P#GG555P5YPGJY5555PPPGB#G5Y555555P&@&GJ7J55PPPPP");
                Console.WriteLine("???GGPP55555555P5J777!!7YY?!!77YY?77?5P??JJPPJY555B@@@@@@&#B55P55?GPJJG5JJJG####GBGBG&G5JJJY5YPYY#@@@@@@@#5JJYYYY#GP555P55PG5BB#BGBBG#&&#G5P5555P&@@P??Y55555PP5");
                Console.WriteLine("????PBBB55555???77777J5P555Y7!!!?555555?GGPP?J5555Y5#@@@@@@@@#PG55BPG55P7?5P55Y5PPPPGG55YJJ5PGP5#@@@@@@&PJJ?JYYJP#PPP5YJ555GPPGGGBGG#@&BGPPPPP5G@@&BJ?G555555555");
                Console.WriteLine("Y55??PB@#P555J7!!?5PPGGB##&&#5J7!?5555Y?#&Y?7?5555YYYP#@@@@@@@JJ5PG55GPGJYPJY5YYJJJJJ55JJJ5GGBB#@@@@@#PJJJ??JJ?J#&#GPPGYJPY5PPPYYYYYPBGP55555YG@&GJY?55555555555");
                Console.WriteLine("PPPJ??J&@@#PP5Y??Y?77YB###BJ?J???J5555J5G#?J??555YYYYYY5B&@@@@Y?PYBPY5GGPY55YYY5PPPPGBG5PGBGBBBBBGGBG5YYYYJJJ5G#&@#BGGPP55PP55PGBBB##BGG55555G@&PJJJ5Y5555555555");
                Console.WriteLine("GPGYY??#@@@@&#BP5Y?J5#####&#J?7Y5555PGP55BJY?J55YYJJYYYYJYPB#@5?GJBG5?5GG5P#G55PPPGGGGGP55PGGGBG555555YYY5PP##@&#@P5PGGGGP5PP555555PGGG555PPB@#55555Y55555555555");
                Console.WriteLine("PPGPPY?B@@@@@@@@#BGP5??????YPGBBBBB#&GY7YBJJJYYYJJ?JJYYJJJJJJGPJBPBGP55GBPGPPJJYY5PPPPBG5PBP5YYJ??JJJJJJ5BJJGPB@#@B55P55GBGP55555555YY555PG#&@#PYYYYYY5YYYYY5555");
                Console.WriteLine("PPPPPPYG@@@@@@@@@@@@&#&&&&##&@@@@@@@GY77JBJ??JJJJJ?JJ?JJJJJJY5B?5G#BB5PPGYY5#BPB#BGP5PBBBPP7777?JJJ??JJJPPJPGP5G#&@&G55PPPG#GPP55PPPGGB#&@@@@@#BPJYYYYYYYYYYYYY5");
                Console.WriteLine("PPPPPPG#@@@@@@@@@@@@@@@@@@@@@@@@@@&PY777YBJ?????????J??????JJJB?YGB#GPGPGY5#&BB&BPYJPPBGB#G55555555PPP5Y5PY55GGGG&@@@&#GGBBGB#&&&&&@@@@@@@@@@&&PBPYYJJJYYJJYYYYY");
                Console.WriteLine("PPPPPB@@@@@@@@@@@@@@@@@@@@@@@@@@@#P5?7??5#&GY?7??7?7??????JJ?7B55BGBGGGGG5#BPGGBPYYGBB#&GPPPPPPPPP5YJJ?5GB?!7JP5G#@@@@@@@&&&@@@@@@@@@@@@@@@@BPGP5BBBG5YJJJJJJJJJ");
                Console.WriteLine("PPPPB@@@@@@@@@@@@@@@@@@@@@@@@@@@B555?JJYP&@@@#PJ?7?77?77777?JGGPY5GGGGGPGGB5G#G5YPBP555G#PPGB#GGG5YJJJYGJGY!!!JP#P#@@@@@@@@@@@@@@@@@@@@@@&&G5P5YYPBBGGGPPP5YJJJP");
                Console.WriteLine("PP5B@@@@@@&&@@@@@@@@@@@@@@@@@@&G5PPPPPPPP&@@@@@&PJ77???5PPG#BP7JY?YG#GGPG#PG#G55GP5YYPB#&BBB&GP5PPGPJ7!YYPP7!!?BB5PGGB&@@@@@@@@@@@@@@@&&###PPJ7!77GG55PGPPPPPPG@");
                Console.WriteLine("BBB@@@@@@@#GB&@@@@@@@@@@@@@@@#P5555PPPPGB&@@@@@@@&G55YJB&BB#5J?JBGPPB#PPB@#&PYPGP5Y5PGB&BG##&BBGGGBBGP5PB5J77!YBYPB#GP5P&@@@@@@@@@@@@##&&&B&&B5777G5777?Y5PPPP#&");
                Console.WriteLine("@@@@@@@@@@@@&&&@@@@@@@@@@@@@@GGGGGBB#&&@@@@@@@@@@@@@@@#BBBBBBBPG#BBBG&PP&@@&PPG55YPGPP##BB#GBGBBBBBB##BGBJ!7JP&&&@@@@@&BB&@@@@@@@@@@@&#B#@B#@@@&57G5!77??7?Y5555");
                Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@#BBBBBB##BGGGG#&@BP&@#@GPGYPGGPGB#&B##BBBBBB##BBB#G555B&@@@@#BB@&&&@@@@@@@@@@@@@@&&&&BB#&&@&5BP7?????7!?555");
            } // end of PrintLargeWelcomeMessage

            static void Loading()
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("                                                                 #                                            ");
                Console.WriteLine("                                                                 #        ####    ##   #####  # #    #  ####  ");
                Console.WriteLine("                                                                 #       #    #  #  #  #    # # ##   # #    # ");
                Console.WriteLine("                                                                 #       #    # #    # #    # # # #  # #      ");
                Console.WriteLine("                                                                 #       #    # ###### #    # # #  # # #  ### ");
                Console.WriteLine("                                                                 #       #    # #    # #    # # #   ## #    # ");
                Console.WriteLine("                                                                 #######  ####  #    # #####  # #    #  ####  ");
            }
            #endregion

            #region "UI Methods"

            // Small header
            static void PrintSmallHeader()
            {
                Console.ForegroundColor= ConsoleColor.White;
                Console.WriteLine("                                                     WELCOME TO THE SLAYER VERSION OF PAPER, ROCK, SCISSORS!!                                                   ");
            }// end of PrintSmallHeader

            // Show menu
            static byte ShowMenu()
            {
                Console.WriteLine();
                MenuBanner();
                Console.WriteLine();
                Seperator();
                Console.WriteLine();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("                                                        Press 1 for a 1 player game against the computer      ");
                    Console.WriteLine("                                                        Press 2 for a 2 player game with a friend             ");
                    Console.WriteLine("                                                        Press 3 to view the rules                             ");
                    Console.WriteLine("                                                        Press 4 to exit                                       ");
                    Console.WriteLine();
                    Console.Write("                                                        Choose [1-4]: ");
                    Console.WriteLine();
                Console.WriteLine();
                Seperator();
                Console.CursorVisible = false;
                byte menuChoice = Convert.ToByte(Console.ReadKey(true).KeyChar);

                Thread.Sleep(0200);
                Console.Clear();
                //return menuChoice;
                if (menuChoice == '1')
                {
                    OnePlayerMode();
                }
                else if (menuChoice == '2')
                {
                    TwoPlayerMode();
                }
                else if (menuChoice == '3')
                {
                    RulesMode();
                }
                else if (menuChoice == '4')
                {
                    ExitOption();
                }
                else
                {
                    Console.WriteLine("                                                             Please enter a valid option.");
                    Thread.Sleep(1000);
                    Console.Clear();
                    ShowMenu();
                }
                return menuChoice;
            } // end of ShowMenu

            // print rules
            static void PrintRules()
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("                                                                 Freddy Krueger beats Michael Myers");
                Console.WriteLine("                                                                 Michael Myers beats Leatherface");
                Console.WriteLine("                                                                 Leatherface beats Freddy Krueger");
            }// end of PrintRules

            // loading method

            #endregion

            #region "UI Screens"

            // layout for the OnePlayerMode
            static void OnePlayerMode()
            {
                PrintSmallHeader();
                Console.WriteLine();
                SinglePlayer();
                Console.WriteLine();
                Console.WriteLine("                                             Stay tuned.... 1 Player mode is coming up with the next JASONTAKEOVER DLC.");
                Thread.Sleep(3000);
                Console.Clear();
                PrintSmallHeader();
                Console.WriteLine();
                ShowMenu();
                Thread.Sleep(2000);
            } // end of OnePlayerMode

            // layout for the TwoPlayerMode
            static void TwoPlayerMode()
            {
                char playerOneChoice, playerTwoChoice;


                PrintSmallHeader();
                Console.WriteLine();
                TwoPlayerBattle();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                PromptForString("                                                        Player One, Please enter your name: ");
                string playerOneName = Console.ReadLine();
                Thread.Sleep(0500);
                Console.WriteLine();
                PromptForString("                                                        Player Two, Please enter your name: ");
                string playerTwoName = Console.ReadLine();
                Thread.Sleep(0500);
                Console.WriteLine();
                Console.WriteLine();
                Seperator();
                Thread.Sleep(2000);
                Console.Clear();
                PrintSmallHeader();
                Console.WriteLine();
                Seperator();
                Versus(playerOneName, playerTwoName);
                Seperator();
                Console.WriteLine();
                Seperator();
                Console.WriteLine();
                PrintRules();
                Console.WriteLine();
                Console.WriteLine("                                                                 Please choose your character ");
                Console.WriteLine("                                                      (Freddy Krueger[1], Michael Myers[2], Leatherface[3]): ");
                Console.WriteLine();
                Seperator();
                Console.WriteLine();
                do
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("                                                             Please enter a number between 1 and 3.");
                    playerOneChoice = PromptForCharHidden("                                                                 " + playerOneName + ":");
                }
                while (playerOneChoice != '1' && playerOneChoice != '2' && playerOneChoice != '3');
                do
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("                                                             Please enter a number between 1 and 3.");
                    playerTwoChoice = PromptForCharHidden("                                                                 " + playerTwoName + ":");
                }
                while (playerTwoChoice != '1' && playerTwoChoice != '2' && playerTwoChoice != '3');
                PrintResults(playerOneName, playerOneChoice, playerTwoName, playerTwoChoice);
                Console.WriteLine();
                Battle();
                Console.WriteLine();
                Seperator();
                Console.WriteLine();
                Loading();
                Thread.Sleep(3000);
                Console.Clear();
                Console.WriteLine();
                CalculateWinner(playerOneChoice, playerTwoChoice);
                byte results = CalculateWinner(playerOneChoice, playerTwoChoice);
                string winner = AnnounceWinner(results, playerOneChoice, playerTwoChoice);
                Console.WriteLine();
                PrintSmallHeader();
                Console.WriteLine();
                Seperator();
                Console.WriteLine();
                ConsoleUtilities.PrintScroll(winner, 025, ConsoleColor.DarkRed);
                Console.WriteLine();
                Seperator();
                Thread.Sleep(1000);
                byte weapon = CalculateWinnerWeapon(playerOneChoice, playerTwoChoice);
                WinnersWeapon(weapon);
                Console.WriteLine();
                Console.Write("                                                                 Would you like to play again (y/n)? ");
                char playAgain = Convert.ToChar(Console.ReadKey(true).KeyChar);
                PlayAgain(playAgain);


        }// end of TwoPlayerMode

            // layout for the Rules
            static void RulesMode()
            {
                PrintSmallHeader();
                Console.WriteLine();
                PrintRules();
                Console.WriteLine();
                PressAnyKey();
                Console.Clear();
                PrintSmallHeader();
                Console.WriteLine();
                ShowMenu();
            } // end of RulesMode

            // layout to exit
            static void ExitOption()
            {
                Console.WriteLine("                                                                       Thanks for playing");
                PrintLargeWelcomeMessage();
                Console.WriteLine();
                Thread.Sleep(3000);
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();

                string end1 = "                                                                               CREDITS:\n";
                string end2 = "                                                                         Created by: Chris Pate:\n";
                string end3 = "                                                        ASCII art created by: https://www.ascii-art-generator.org/ \n\n";
               
                ConsoleUtilities.PrintScroll(end1, 005, ConsoleColor.DarkRed);
                Console.WriteLine();
                ConsoleUtilities.PrintScroll(end2, 005, ConsoleColor.DarkRed);
                Console.WriteLine();
                ConsoleUtilities.PrintScroll(end3, 005, ConsoleColor.DarkRed);

                Thread.Sleep(2000);
            } // end of ExitOption  
            #endregion

            #region "Player Wins"

            // Create method for winners weapon
            static void WinnersWeapon(byte results)
            {
                if (results == '1')
                {
                    Console.WriteLine();
                    FreddyQuote();
                    Thread.Sleep(2000);
                    FreddyKrueger();
                }
                else if (results == '2')
                {
                    Console.WriteLine();
                    MyersQuote();
                    Thread.Sleep(2000);
                    MichaelMyers();
                }
                else if (results == '3')
                {
                    Console.WriteLine();
                    LeatherfaceQuotes();
                    Thread.Sleep(2000);
                    Leatherface();
                }
            }

            static void MyersQuote()
            {
                string mmq1 = "                                                   When Michael Myers was six years old, he stabbed hs sister to death.\n";
                string mmq2 = "                                                   He was locked up for years in Smith's Grove Sanitarium, but he escaped.\n";
                string mmq3 = "                                                   Soon after, Halloween became another word for mayhem!\n";
                string mmq4 = "                                                   One by one, he killed his entire family, until his nine-year-old niece,\n";
                string mmq5 = "                                                   Jamie Lloyd, was the only one left alive.\n";
                string mmq6 = "                                                   Six years ago, Halloween night, Michael and Jamie vanished.\n\n";
                string mmq7 = "                                                                                                     ~ PAUL RUDD - Tommy Doyle";
                Console.WriteLine();
                ConsoleUtilities.PrintScroll(mmq1, 005, ConsoleColor.DarkRed);
                Console.WriteLine();
                ConsoleUtilities.PrintScroll(mmq2, 005, ConsoleColor.DarkRed);
                Console.WriteLine();
                ConsoleUtilities.PrintScroll(mmq3, 005, ConsoleColor.DarkRed);
                Console.WriteLine();
                ConsoleUtilities.PrintScroll(mmq4, 005, ConsoleColor.DarkRed);
                Console.WriteLine();
                ConsoleUtilities.PrintScroll(mmq5, 005, ConsoleColor.DarkRed);
                Console.WriteLine();
                ConsoleUtilities.PrintScroll(mmq6, 005, ConsoleColor.DarkRed);
                Console.WriteLine();
                ConsoleUtilities.PrintScroll(mmq7, 005, ConsoleColor.DarkRed);
            }

            // Create a method for when Michael Myers wins
            static void MichaelMyers()
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Clear();

                // Create knife for Michael Myers
                Console.WriteLine(" .^");
                Console.WriteLine(".!^:.^");
                Console.WriteLine(".~~~^^:.^");
                Console.WriteLine(".~~^^:::::.^");
                Console.WriteLine(" :!~:::.::^ ~^.");
                Console.WriteLine("  :7~....::^ ~!!^.");
                Console.WriteLine("  .^ 7!....:^^^~!7~:");
                Console.WriteLine("   .^77...::^ ^^^~77!:");
                Console.WriteLine("     :!? ^.. : ^^^^^~!77!");
                Console.WriteLine("      .~? !.. : ^^::^ ~!!!7!");
                Console.WriteLine("       .^ 7 ? ~::::.: ^~~!!!!~");
                Console.WriteLine("          :~? 7~^:...^~~!!!~~^:. ");
                Console.WriteLine("           .^7J7 ^ ...:^~~~~~~^^::.");
                Console.WriteLine("              .~?? ~...:^~~~~~^^::::.");
                Console.WriteLine("                :~? 7 ^ .. : ^~~~~~^::::");
                Console.WriteLine("                 .:!? !:.:^~~~~^^:...::::.");
                Console.WriteLine("                  .:!? !^^^^^~^^: ..::.:^^^:");
                Console.WriteLine("                    .^!? 7~^^^^^^:.::^ ^~^^~~:");
                Console.WriteLine("                      .^7 ?? !~^^^:...:^^::^ ~!~:");
                Console.WriteLine("                        .^7J ? !^^::....::.: ^~!~~:");
                Console.WriteLine("                          .^7J ? !^::.......^ ~~~^:^~.");
                Console.WriteLine("                            .^ !J ? !::...... : ^^^~77:^~:");
                Console.WriteLine("                              .^!? 7~:......:~YPJ! ^ ..^7~.");
                Console.WriteLine("                               .:!?? !::^ ~!75P5YJ??7 ? PGP ?");
                Console.WriteLine("                                 .: !???? 77!!!7?JYYGBGP ? 75Y!");
                Console.WriteLine("                                      ..::...   ..^!J5PGGJ7Y5P5J~.");
                Console.WriteLine("                                                 . :!J5PGP55555P5?^");
                Console.WriteLine("                                                   .: !J5GGP55555PPY7:");
                Console.WriteLine("                                                    .^!JPGPPP5555J55J ^");
                Console.WriteLine("                                                      .^ !J5GGPPPJ~? P5PY~");
                Console.WriteLine("                                                        .^ !? 5PGPPP55555PY^");
                Console.WriteLine("                                                          .:~7YPGGPP5555PP7.^");
                Console.WriteLine("                                                            .:^!J5GGPP5555PY:.^");
                Console.WriteLine("                                                              . :!J5GGP555YP5:.^");
                Console.WriteLine("                                                                . :!JPBGPY ^ 7P5:^");
                Console.WriteLine("                                                                  . ^? PBG555PGJ:,^");
                Console.WriteLine("                                                                    . ^? GBGPP5J!:.^");
                Console.WriteLine("                                                                      . ^ 7 ??? 7!:.^");
                Console.WriteLine("                                                                        .  ....::..^");


                Console.WriteLine("Michael Myers WINS!");
            }
            static void FreddyQuote()
            {
                string fkq1 = "                                                                     One, two, Freddy’s coming for you.\n";
                string fkq2 = "                                                                     Three, four, better lock your door.\n";
                string fkq3 = "                                                                     Five, six, grab your crucifix.\n";
                string fkq4 = "                                                                     Seven, eight, gonna stay up late.\n";
                string fkq5 = "                                                                     Nine, ten, never sleep again.\n\n";
                Console.WriteLine();
                string fkq6 = "                                                                              ~ A Nightmare on Elm Street (1984)";
                ConsoleUtilities.PrintScroll(fkq1, 005, ConsoleColor.DarkRed);
                Console.WriteLine();
                ConsoleUtilities.PrintScroll(fkq2, 005, ConsoleColor.DarkRed);
                Console.WriteLine();
                ConsoleUtilities.PrintScroll(fkq3, 005, ConsoleColor.DarkRed);
                Console.WriteLine();
                ConsoleUtilities.PrintScroll(fkq4, 005, ConsoleColor.DarkRed);
                Console.WriteLine();
                ConsoleUtilities.PrintScroll(fkq5, 005, ConsoleColor.DarkRed);
                Console.WriteLine();
                ConsoleUtilities.PrintScroll(fkq6, 005, ConsoleColor.DarkRed);
            }

            // Create a method for when Freddy Krueger wins
            static void FreddyKrueger()
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Clear();


                // Create glove for Freddy Kruger
                Console.WriteLine("                                                              .'.                         ");
                Console.WriteLine("                                                               .;;.                       ");
                Console.WriteLine("                                                                .;:.                      ");
                Console.WriteLine("                                                                 .::.                     ");
                Console.WriteLine("                            'c:'.                                 ,c:.                    ");
                Console.WriteLine("                            .:x00kc'                              .:c,                    ");
                Console.WriteLine("                               .:dKKx;.                            ,l:.                   ");
                Console.WriteLine("                                  .:kOo;.                          .cl'                   ");
                Console.WriteLine("                                    .;x0k:.                        .;c,                   ");
                Console.WriteLine("                                      .cOKx,                        .,.                   ");
                Console.WriteLine("             ...                        .oK0l'.                     .;'.                  ");
                Console.WriteLine("              .......                     ,kKKx'                    .::.                  ");
                Console.WriteLine("                  ...'..                   .lkOOc.                  .cl,.                 ");
                Console.WriteLine("                      ..'...                 .:OKd'                .'cl;.                 ");
                Console.WriteLine("                         .''..                 ,d0kc.             .cdol:'.                ");
                Console.WriteLine("                           ..'..               .,ldxl'.            :OOxoc'                ");
                Console.WriteLine("                             ....               ,dO0Oxl,.          'kKOxdc.               ");
                Console.WriteLine("                                                 .lOKK0kdc.        'xK0kkd,               ");
                Console.WriteLine("                                    ......         ,oxkOOd:'..     .ldkkxo,               ");
                Console.WriteLine("                                    , oddoc,...      .,coxkddoc,.   .,lxkxdl,              ");
                Console.WriteLine("                                    'cdk00Odlc;'.    ..,cxOkkdoc;. .;lxOkxdl.             ");
                Console.WriteLine("                                      .;ldxkOOOxo:;,.....;okOkxdol:,',lkkkxo;             ");
                Console.WriteLine("            ..                          .';codxO00Okdl:,'';:oxOkdolcc:,,:ddl:.            ");
                Console.WriteLine("             ....,::;'..                   .',;:ok00Okdooollllllclc,,;:;':l:;'.           ");
                Console.WriteLine("                 .';:clolc;,...               ..',:ldkOOkxdlcclc:;:;;;;:;;cc:,.           ");
                Console.WriteLine("                      ..';codddoc,.......     .....';:looolc:clccclcc::ccc:;,,.           ");
                Console.WriteLine("                            .';coocldxxdollcccldddxxxxdddoccllllloddooolllc:;;,.          ");
                Console.WriteLine("                               .:looxkxxkkkkkkO0KKKKXKOdlccclxkkxxdddddoooool:;;.         ");
                Console.WriteLine("                                 ....';cllcccldxxdddxdooddoolokOkxdxdoooooddolc:;.        ");
                Console.WriteLine("                                 ....';cllcccldxxdddxdooddoolokOkxdxdoooooddolc:;.        ");
                Console.WriteLine("                                 ....';cllcccldxxdddxdooddoolokOkxdxdoooooddolc:;.        ");
                Console.WriteLine("                                        .......,,...,,,:odcclldkkxddocllcloooolc:.        ");
                Console.WriteLine("                                                       .colooddxxkkxollodxxxxkxdo'        ");
                Console.WriteLine("                                     .''',,,'...       .locoddxdooolclxkkkkkkkxxxo'       ");
                Console.WriteLine("                                     .cloxxkkxxdl:,..  .lxddolc:;,:coxkxdxxxkxxkOko;.     ");
                Console.WriteLine("                                       .cxxkOOOkkkkxd:''cxxdoooc;;clodxdxxkxxxkkkxddc.    ");
                Console.WriteLine("                                        .,oxkkxddooxkxolddddxdlcccccldxxxkkkkxxkkkkkkd:.  ");
                Console.WriteLine("                                          .':lodocoxxxddxdddxkdlldxddxkkxxxxxxxkxxxkkkkc. ");
                Console.WriteLine("                                              .':ldxxxxddddddddoodxkkkxxxxxxxxxkdodxdoc;. ");
                Console.WriteLine("                                                  .;cdxxxxddddddxkxxdllloxxxdxkkxoc,....  ");
                Console.WriteLine("                                                     .';codoldxddkkkocldxkxxkkdc,'.       ");
                Console.WriteLine("                                                         .',';ccclodddxkkkxlccc;'..       ");
                Console.WriteLine("                                                               ..,ldddxkkxl:;;:;..        ");

                Console.WriteLine("Freddy Wins!");
            }
            // Leatherface quotes
            static void LeatherfaceQuotes()
            {
                string lfq1 = "                                                                     In the summer of 1973, \n";
                string lfq2 = "                                                                     a few miles outside of Austin, Texas, \n";
                string lfq3 = "                                                                     five youths were attacked in a grisly \n";
                string lfq4 = "                                                                     and gruesome fashion by an \n ";
                string lfq5 = "                                                                     unidentified madman.";
                ConsoleUtilities.PrintScroll(lfq1, 005, ConsoleColor.DarkRed);
                Console.WriteLine();
                ConsoleUtilities.PrintScroll(lfq2, 005, ConsoleColor.DarkRed);
                Console.WriteLine();
                ConsoleUtilities.PrintScroll(lfq3, 005, ConsoleColor.DarkRed);
                Console.WriteLine();
                ConsoleUtilities.PrintScroll(lfq4, 005, ConsoleColor.DarkRed);
                Console.WriteLine();
                ConsoleUtilities.PrintScroll(lfq5, 005, ConsoleColor.DarkRed);

                Console.WriteLine();
            }


            // Create a method for when Leatherface wins
            static void Leatherface()
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Clear();

                // Create chainsaw for Leatherface
                Console.WriteLine("                                                              .                                     ");
                Console.WriteLine("                                                           ^???JJ?!^:.                              ");
                Console.WriteLine("                                                          ? P! .^~7JYYYJ!                           ");
                Console.WriteLine("                                                         ~B!        .^~:                            ");
                Console.WriteLine("                                                         J5.     ...:^~~~!~^^^^^^::::::::..         ");
                Console.WriteLine("                                                         5Y.~!!!!!777JJ?JJJ??????77???JJJJ??7~.     ");
                Console.WriteLine("                                                        .PJ~GBBGGPYY57!!!!!!777JJ?YJJYYJY55555J~    ");
                Console.WriteLine("                                                       ~YGGGBBBGBGPPG7~!777?YYYYYJYY5YP5J?J5P5557   ");
                Console.WriteLine("                                       ..  :^:.:~^^!~~^7YYYYPBBBBGBBG?7???Y5J7777?J5GGGGPP5:!PGP5~  ");
                Console.WriteLine("                       ..  :^..:!:^!?^^~7~^!^~~^^^^^^^!7??!YGBBBGBB5?777?7??7JJ?77??7JY5PPY. ~GBPJ. ");
                Console.WriteLine("          ^ ^.::7~^^~~~~!?~~!7~~^~~!~^^:::::~~^^:::::^^~!7?YBGGGGBBJ77???JJ?777!!J?~::^~7JJ7   P#G5. ");
                Console.WriteLine("     ~J~777!!7!!!!!!!!!!~~~^::::^~!!^:::::^~~~!^:::^~~~!7JGBGGGGG5!??????J???~^~J?::^^^^7Y?^~7PGPY  ");
                Console.WriteLine("   .??7!~~~~~~^^^^!!~!!!!!!~:::::^~~^:::::::^~~^::^~77!!?YBBGGGGBY7?????!???Y?!?Y?^~^^^~?YYYYJ?7!.  ");
                Console.WriteLine("  7J7~!~~7??77!^:^!!^^~~~^^::::::^^^^::^~~^::^^^:^^!!77??PBBBBBB#G??????JYYJY5JJ55J7~~7?YY?.        ");
                Console.WriteLine("  ~5^!!~!!7?J77~^^!!~~~~~^^^~~^:::^^^^~~~!!!77777~~7!::^:J5PGBB###5???JJJY5Y?Y5555YJ??7!!~.         ");
                Console.WriteLine("  ^ P?!7!!77777!^^^^~!!!~~~~~~!!~!?7!7Y7!77^:!^ ..          ..^~7?Y5?77!!~~!!^~^^::..                ");
                Console.WriteLine("  :?? J7!!!7!77!!7777?J!~!?!~~Y~:^!...:                                                              ");
                Console.WriteLine("     :!?^!~?5!~~J~:.^~  ..                                                                          ");
                Console.WriteLine("       .    .                                                                                       ");

                Console.WriteLine("Leatherface WINS!");
            }
            #endregion
        }// end of main        
    }// end of class
} // end of namespace