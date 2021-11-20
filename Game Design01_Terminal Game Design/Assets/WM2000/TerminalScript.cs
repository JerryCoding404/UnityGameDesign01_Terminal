using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalScript : MonoBehaviour
{
    //GameStates init :Level/Screen
    int level;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen = Screen.MainMenu;
    //Game Confiquration
    string[] Lv1Passwords = {"plate","chair","laptop","glass","air conditioner","books","sofa","spoon","light","bag"};
    string[] Lv2Passwords = {"towel","water","metal","muscle","data","music","sneaker","training","sweat","pipes"};
    string[] Lv3Passwords = {"colume","students","magazine","guard","lobby","painting","printer","paper","computer","celling"};
    string password;
    //Player Confiquration
    enum GamePlayer { Player1, Player2 };
    GamePlayer currentPlayer;
    string Player;
    //Point Confiquration
    int P1_Point = 0;
    int P2_Point = 0;
    // Start is called before the first frame update
    void Start()
    {
       StartMainMenu("Hello, Wellcome To Hacker.net! Human!");
    }

    void StartMainMenu (string greeting) 
    {
        SwitchPlayer();
        ConfiPlayer();

        Screen currentScreen = Screen.MainMenu;
        print("player is " + Player);
        
        Terminal.WriteLine(greeting);
        Terminal.WriteLine("Player1 Points: " + P1_Point + "   Player2 Points: " + P2_Point);
        Terminal.WriteLine("Now Player is: " + Player);
        Terminal.WriteLine("What would you want to hack in to?");
        Terminal.WriteLine("1. A Restaurant");
        Terminal.WriteLine("2. A Gym");
        Terminal.WriteLine("3. A Library");
        Terminal.WriteLine("Please Choose Your Selection: ");
    }
    void OnUserInput(string input)
	{
        if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
        else if (currentScreen == Screen.Win)
        {
            ReturnMenu(input);
        }
	}
    void RunMainMenu(string input)
    {
        if (input == "1" || input == "2" || input == "3")
        {
            level = int.Parse(input);
            print("Input succeed!");
            StartGame();
        }
        else if (input == "menu")
        {
            currentScreen = Screen.MainMenu;
            level = 0;
            Terminal.ClearScreen();
            print("Input menu succeed!");
            StartMainMenu("Hello, Wellcome To Hacker.net! Human!");
        }
        //回到MENU
        else if(input == "jerry")
        {
            print("Input jerry succeed!");
            Terminal.WriteLine("Who said you can call my name?");
        }
        //彩蛋jerry
        else 
        {
            Terminal.WriteLine("Please select a vaild number");
        }
        //input 數字level或是選擇好的數字       

        void StartGame()
        {
            currentScreen = Screen.Password;
            Terminal.ClearScreen();
            Terminal.WriteLine("You Have Choose Level" + level);
            switch(level)
            {
                case 1:
                    password = Lv1Passwords[Random.Range(0, Lv1Passwords.Length)];
                    break;
                case 2:
                    password = Lv2Passwords[Random.Range(0, Lv2Passwords.Length)];
                    break;
                case 3:
                    password = Lv3Passwords[Random.Range(0, Lv3Passwords.Length)];
                    break;
                default:
                    Debug.LogError("Invaild Level Number");
                    break;
            }
            Terminal.WriteLine("Please input your password, hint: " + password.Anagram());
            print("StartGame succeed!");
        }
        //開始遊戲1、2、3的遊戲內容設置
    }
    // Update is called once per frame
    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen(input);
        }
        else
        {
            Terminal.WriteLine("try again!");
        }
        if(input == "menu")
        {
            currentScreen = Screen.MainMenu;
            level = 0;
            Terminal.ClearScreen();
            StartMainMenu("Hello, Wellcome To Hacker.net! Human!");
        }
        //回到MENU
        else if(input == "jerry")
        {
            Terminal.WriteLine("Who said you can call my name?");
        }
        //彩蛋jerry
    }
    void DisplayWinScreen(string input)
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        addPoint();
        print("add point succeed!");
        ShowLevelReward(input);
    }
    void ShowLevelReward(string input)
    {
        Terminal.WriteLine("The answer is " + password);
        Terminal.WriteLine("GOOD JOB!!!");
        Terminal.WriteLine("Do You Want To Try Again?");
        Terminal.WriteLine("Please type 'menu'...");
        ReturnMenu(input);
    }
    void ReturnMenu(string input)
    {
        if (input == "menu")
        {
            currentScreen = Screen.MainMenu;
            level = 0;
            Terminal.ClearScreen();
            print("Input menu succeed!");
            StartMainMenu("Hello, Wellcome To Hacker.net! Human!");
        }
        //回到MENU
        else if(input == "jerry")
        {
            print("Input jerry succeed!");
            Terminal.WriteLine("Who said you can call my name?");
        }
        //彩蛋jerry
    }
    void addPoint()
    {
        if (currentPlayer == GamePlayer.Player1)
        {
            P1_Point = P1_Point + 1;
        }
        else if (currentPlayer == GamePlayer.Player2)
        {
            P2_Point = P2_Point + 1;
        }
    }
    void ConfiPlayer()
    {
        if (currentPlayer == GamePlayer.Player1)
        {
            Player = "Player1";
            print("ConfiPlayer1");
        }
        else if (currentPlayer == GamePlayer.Player2)
        {
            Player = "Player2";
            print("ConfiPlayer2");
        }
    }
    void SwitchPlayer()
    {
        if (P1_Point == 0 & P2_Point == 0)
        {
            currentPlayer = GamePlayer.Player1;
            print("initToPlayer1");
            //First Game
        }
        else if (currentPlayer == GamePlayer.Player1)
        {
            currentPlayer = GamePlayer.Player2;
            print("SwitchToPlayer2");
        }
        else if (currentPlayer == GamePlayer.Player2)
        {
            currentPlayer = GamePlayer.Player1;
            print("SwitchToPlayer1");
        }
    }
    void Update()
    {
        
    }
}
