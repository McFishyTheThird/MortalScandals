using Raylib_cs;

public class Methods
{
    Random generator = new Random();
    //character and bot variables
    Texture2D startBG = Raylib.LoadTexture("StartBG.png");
    Texture2D victory = Raylib.LoadTexture("Victory.png");
    Texture2D backGround = Raylib.LoadTexture("BG.png");
    Texture2D groundDirt = Raylib.LoadTexture("GroundDirt.png");
    Texture2D groundGrass = Raylib.LoadTexture("Ground.png");
    //Average Man
    Player p = new Player() {playerCharacter = Raylib.LoadTexture($"AverageMan/CharacterRight.png"), playerPlace = new Rectangle(0, 600, 100, 200), pYMax = 600, jumpPower = 15, jumpPowerMax = 16, jumpPowerMin = 15, hpMax = 800, speed = 5, punchDamageMax = 51, punchDamageMin = 50, punchCooldown = 0.5f, punchCooldownMax = 0.5f, knockback = 20, knockbackMax = 21, knockbackMin = 20, knockbackImmunity = 0, canCrouch = 1, punchingLeftXPunch = 100, punchingLeftXJumpPunch = 50};
    //Chill Bro
    Player pIce = new Player() {playerCharacter = Raylib.LoadTexture($"ChillBro/CharacterRight.png"), playerPlace = new Rectangle(0, 600, 100, 200), pYMax = 600, jumpPower = 0, jumpPowerMax = 1, jumpPowerMin = 0, hpMax = 750, speed = 10, punchDamageMax = 81, punchDamageMin = 80, punchCooldown = 1f, punchCooldownMax = 1f, knockback = 30, knockbackMax = 31, knockbackMin = 30, knockbackImmunity = 0, canCrouch = 1, punchingLeftXPunch = 100, punchingLeftXJumpPunch = 50};
    //Phantom Buckaroo
    Player pEdgy = new Player() {playerCharacter = Raylib.LoadTexture($"PhantomBuckaroo/CharacterRight.png"), playerPlace = new Rectangle(0, 600, 100, 200), pYMax = 600, jumpPower = 15, jumpPowerMax = 16, jumpPowerMin = 15, hpMax = 800, speed = 5, punchDamageMax = 61, punchDamageMin = 60, punchCooldown = 0.4f, punchCooldownMax = 0.4f, knockback = 25, knockbackMax = 26, knockbackMin = 25, knockbackImmunity = 0, canCrouch = 0, punchingLeftXPunch = 100, punchingLeftXJumpPunch = 50};
    //Walmart Bruce Lee
    Player pTokyo = new Player() {playerCharacter = Raylib.LoadTexture($"WalmartBruceLee/CharacterRight.png"), playerPlace = new Rectangle(0, 600, 100, 200), pYMax = 600, jumpPower = 20, jumpPowerMax = 21, jumpPowerMin = 20, hpMax = 600, speed = 13, punchDamageMax = 31, punchDamageMin = 30, punchCooldown = 0.2f, punchCooldownMax = 0.2f, knockback = 10, knockbackMax = 11, knockbackMin = 10, knockbackImmunity = 0, canCrouch = 1, punchingLeftXPunch = 100, punchingLeftXJumpPunch = 50};
    //Jack Of All Trades
    Player pAce = new Player() {playerCharacter = Raylib.LoadTexture($"JackOfAllTrades/CharacterRight.png"), playerPlace = new Rectangle(0, 588, 100, 200), pYMax = 588, jumpPower = 10, jumpPowerMax = 21, jumpPowerMin = 2, hpMax = 1000, speed = 7, punchDamageMax = 121, punchDamageMin = 10, punchCooldown = 0.75f, punchCooldownMax = 0.75f, knockback = 10, knockbackMax = 26, knockbackMin = 0, knockbackImmunity = 0, canCrouch = 1, punchingLeftXPunch = 100, punchingLeftXJumpPunch = 50};
    //General Duckington
    Player pDuck = new Player() {playerCharacter = Raylib.LoadTexture($"GeneralDuckington/CharacterRight.png"), playerPlace = new Rectangle(0, 600, 100, 200), pYMax = 600, jumpPower = 10, jumpPowerMax = 11, jumpPowerMin = 10, hpMax = 800, speed = 5, punchDamageMax = 81, punchDamageMin = 80, punchCooldown = 0.6f, punchCooldownMax = 0.6f, knockback = 30, knockbackMax = 31, knockbackMin = 30, knockbackImmunity = 0, canCrouch = 1, punchingLeftXPunch = 100, punchingLeftXJumpPunch = 50};
    //BEE!!
    Player pBee = new Player() {playerCharacter = Raylib.LoadTexture($"HonkBee/CharacterRight.png"), playerPlace = new Rectangle(0, 600, 100, 200), pYMax = 600, jumpPower = 20, jumpPowerMax = 21, jumpPowerMin = 20, hpMax = 750, speed = 10, punchDamageMax = 76, punchDamageMin = 75, punchCooldown = 0.75f, punchCooldownMax = 0.75f, knockback = 20, knockbackMax = 21, knockbackMin = 15, knockbackImmunity = 0, canCrouch = 1, punchingLeftXPunch = 100, punchingLeftXJumpPunch = 50};
    //Naughty Smasher
    Player pNaughty = new Player() {playerCharacter = Raylib.LoadTexture($"NaughtySmasher/CharacterRight.png"), playerPlace = new Rectangle(0, 575, 100, 200), pYMax = 575, jumpPower = 15, jumpPowerMax = 16, jumpPowerMin = 15, hpMax = 800, speed = 3, punchDamageMax = 101, punchDamageMin = 100, punchCooldown = 1.5f, punchCooldownMax = 1.5f, knockback = 20, knockbackMax = 21, knockbackMin = 20, knockbackImmunity = 0, canCrouch = 1, punchingLeftXPunch = 100, punchingLeftXJumpPunch = 50};
    //Jesus Bezos
    Player pSecret = new Player() {playerCharacter = Raylib.LoadTexture($"SecretCharacter/CharacterRight.png"), playerPlace = new Rectangle(0, 398, 100, 200), pYMax = 398, jumpPower = 2, jumpPowerMax = 3, jumpPowerMin = 2, hpMax = 1200, speed = 3, punchDamageMax = 421, punchDamageMin = 69, punchCooldown = 0.1f, punchCooldownMax = 0.1f, knockback = 6, knockbackMax = 10, knockbackMin = 6, knockbackImmunity = 1, canCrouch = 0, punchingLeftXPunch = 100, punchingLeftXJumpPunch = 100};
    //Bot: Average Man
    Bot b = new Bot() {botCharacter = Raylib.LoadTexture($"AverageMan/CharacterLeft.png"), botPlace = new Rectangle(1820, 600, 100, 200), bYMax = 600, jumpPower = 15, jumpPowerMax = 16, jumpPowerMin = 15, hpMax = 800, speed = 5, punchDamageMax = 51, punchDamageMin = 50, punchCooldown = 0.5f, punchCooldownMax = 0.5f, knockback = 20, knockbackMax = 21, knockbackMin = 20, punchingLeftXPunch = 100, punchingLeftXJumpPunch = 50};
    //Bot: Chill Bro
    Bot bIce = new Bot() {botCharacter = Raylib.LoadTexture($"ChillBro/CharacterLeft.png"), botPlace = new Rectangle(1820, 600, 100, 200), bYMax = 600, jumpPower = 0, jumpPowerMax = 1, jumpPowerMin = 0, hpMax = 750, speed = 10, punchDamageMax = 81, punchDamageMin = 80, punchCooldown = 1f, punchCooldownMax = 1f, knockback = 30, knockbackMax = 31, knockbackMin = 30, punchingLeftXPunch = 100, punchingLeftXJumpPunch = 50};
    //Bot: Phantom Buckaroo
    Bot bEdgy = new Bot() {botCharacter = Raylib.LoadTexture($"PhantomBuckaroo/CharacterLeft.png"), botPlace = new Rectangle(1820, 600, 100, 200), bYMax = 600, jumpPower = 15, jumpPowerMax = 16, jumpPowerMin = 15, hpMax = 800, speed = 5, punchDamageMax = 61, punchDamageMin = 60, punchCooldown = 0.4f, punchCooldownMax = 0.4f, knockback = 25, knockbackMax = 26, knockbackMin = 25, punchingLeftXPunch = 100, punchingLeftXJumpPunch = 50};
    //Bot: Walmart Bruce Lee
    Bot bTokyo = new Bot() {botCharacter = Raylib.LoadTexture($"WalmartBruceLee/CharacterLeft.png"), botPlace = new Rectangle(1820, 600, 100, 200), bYMax = 600, jumpPower = 20, jumpPowerMax = 21, jumpPowerMin = 20, hpMax = 600, speed = 13, punchDamageMax = 31, punchDamageMin = 30, punchCooldown = 0.2f, punchCooldownMax = 0.2f, knockback = 10, knockbackMax = 11, knockbackMin = 10, punchingLeftXPunch = 100, punchingLeftXJumpPunch = 50};
    //Bot: Jack of all trades
    Bot bAce = new Bot() {botCharacter = Raylib.LoadTexture($"JackOfAllTrades/CharacterLeft.png"), botPlace = new Rectangle(1820, 588, 100, 200), bYMax = 588, jumpPower = 10, jumpPowerMax = 21, jumpPowerMin = 2, hpMax = 1000, speed = 7, punchDamageMax = 121, punchDamageMin = 10, punchCooldown = 0.75f, punchCooldownMax = 0.75f, knockback = 10, knockbackMax = 26, knockbackMin = 0, punchingLeftXPunch = 100, punchingLeftXJumpPunch = 50};
    //Bot: General Duckington
    Bot bDuck = new Bot() {botCharacter = Raylib.LoadTexture($"GeneralDuckington/CharacterLeft.png"), botPlace = new Rectangle(1820, 600, 100, 200), bYMax = 600, jumpPower = 10, jumpPowerMax = 11, jumpPowerMin = 10, hpMax = 800, speed = 5, punchDamageMax = 81, punchDamageMin = 80, punchCooldown = 0.6f, punchCooldownMax = 0.6f, knockback = 30, knockbackMax = 31, knockbackMin = 30, punchingLeftXPunch = 100, punchingLeftXJumpPunch = 50};
    //Bot: Honk Bee
    Bot bBee = new Bot() {botCharacter = Raylib.LoadTexture($"HonkBee/CharacterLeft.png"), botPlace = new Rectangle(1820, 600, 100, 200), bYMax = 600, jumpPower = 20, jumpPowerMax = 21, jumpPowerMin = 20, hpMax = 750, speed = 10, punchDamageMax = 76, punchDamageMin = 75, punchCooldown = 0.75f, punchCooldownMax = 0.75f, knockback = 20, knockbackMax = 21, knockbackMin = 15, punchingLeftXPunch = 100, punchingLeftXJumpPunch = 50};
    //Bot: Naughty Smasher
    Bot bNaughty = new Bot() {botCharacter = Raylib.LoadTexture($"NaughtySmasher/CharacterLeft.png"), botPlace = new Rectangle(1820, 575, 100, 200), bYMax = 575, jumpPower = 15, jumpPowerMax = 16, jumpPowerMin = 15, hpMax = 800, speed = 3, punchDamageMax = 101, punchDamageMin = 100, punchCooldown = 1.5f, punchCooldownMax = 1.5f, knockback = 20, knockbackMax = 21, knockbackMin = 20, punchingLeftXPunch = 100, punchingLeftXJumpPunch = 50};
    Player pCharacter = new Player();
    Bot bCharacter = new Bot();
    //ground
    string pCName = "Average Man";
    string bCName = "Average Man";
    Rectangle ground = new Rectangle(0, 800, 2000, 200);
    Rectangle characterSelect = new Rectangle(0,0,0,0);
    int selectedCharacter = 1;
    string player = "AverageMan";
    string bot = "AverageMan";
    //scene
    string currentScene = "start";
    //pretty self explanatory variables
    int isJumping = 0;
    int isCrouching = 0;
    int isPunching = 0;
    int isLookingRight = 1;
    int isLookingLeft = 0;
    int loadCharacter = 0;
    int punchHit = 0;
    string trackCurrentScene;
    Texture2D[] baguettes = { Raylib.LoadTexture("Baguette1.png"), Raylib.LoadTexture("Baguette2.png") };

    public void MortalScandals()
    {
        while (!Raylib.WindowShouldClose())
        {
            Controls();
            if (currentScene == "start")
            {
                Start();
                TrackingScene();
                Baguettes();
            }
            else if (currentScene == "selection")
            {
                Selection();
                TrackingScene();
            }
            else if (currentScene == "game")
            {
                Game();
                TrackingScene();
            }
            else if (currentScene == "end")
            {
                //end scene
                pCharacter.Restart(pSecret, pCharacter, bCharacter, player, bot, ref currentScene, ref isJumping, ref isCrouching, ref isPunching, ref isLookingRight, ref isLookingLeft, ref punchHit);
            }
            else if (currentScene == "victory")
            {
                //victory
                pCharacter.Restart(pSecret, pCharacter, bCharacter, player, bot, ref currentScene, ref isJumping, ref isCrouching, ref isPunching, ref isLookingRight, ref isLookingLeft, ref punchHit);
            }
            else if (currentScene == "controls")
            {
                DrawControls();
            }
            else if (currentScene == "baguettetime!!!")
            {
                BaguetteScene();
            }
            Drawing();
        }
    }

    private void BaguetteScene()
    {
        
    }
    private void Baguettes()
    {
        if(Raylib.IsKeyPressed(KeyboardKey.KEY_X))
        {
            currentScene = "baguettetime!!!";
        }
    }
    private void Drawing()
    {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.WHITE);
        //graphics
        if (currentScene == "start")
        {
            StartDraw();
        }
        else if (currentScene == "selection")
        {
            SelectionDraw();
        }
        else if (currentScene == "game")
        {
            GameDraw();
        }
        else if (currentScene == "end")
        {
            EndDraw();
        }
        else if (currentScene == "victory")
        {
            VictoryDraw();
        }
        Raylib.EndDrawing();
    }
    private void Controls()
    {
        if(Raylib.IsKeyPressed(KeyboardKey.KEY_Q))
        {
            currentScene = "controls";
        }
    }
    private void DrawControls()
    {
        ReturnToGame();
        Raylib.DrawText("CONTROLS:", 30, 30, 30, Color.BLACK);
        Raylib.DrawText("Tab to restart or unpause", 30, 90, 30, Color.BLACK);
        Raylib.DrawText("A,D to move left and right", 30, 60, 30, Color.BLACK);
        Raylib.DrawText("J,L to Punch", 30, 120, 30, Color.BLACK);
        Raylib.DrawText("W to Jump", 30, 150, 30, Color.BLACK);
        Raylib.DrawText("S to Crouch (Does nothing)", 30, 180, 30, Color.BLACK);
        Raylib.DrawText("Q to pause", 30, 210, 30, Color.BLACK);
        Raylib.DrawText("GOALS:", 30, 270, 30, Color.BLACK);
        Raylib.DrawText("Punch your opponent", 30, 300, 30, Color.BLACK);
        Raylib.DrawText("Try to get your opponent to 0 hp", 30, 330, 30, Color.BLACK);
        Raylib.DrawText("Try to stay above 0 hp", 30, 360, 30, Color.BLACK);
        Raylib.DrawText("TIPS:", 30, 420, 30, Color.BLACK);
        Raylib.DrawText("All characters have different stats", 30, 450, 30, Color.BLACK);
        Raylib.DrawText("There are 8 characters to choose from", 30, 480, 30, Color.BLACK);
        Raylib.DrawText("The opponents character is in the top right of the selection screen", 30, 510, 30, Color.BLACK);
        Raylib.DrawText("You start to the left", 30, 540, 30, Color.BLACK);
        Raylib.DrawText("The opponent starts to the right", 30, 570, 30, Color.BLACK);
        Raylib.DrawText("The opponent is an bad AI", 30, 600, 30, Color.BLACK);
        Raylib.DrawText("Tab to go back", 500, 800, 60, Color.BLACK);
    }
 
    private void ReturnToGame()
    {
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_TAB))
        {
            currentScene = trackCurrentScene;
        }
    }

    private void VictoryDraw()
    {
        //victory screen
        Raylib.DrawTexture(victory, 0, 0, Color.WHITE);
    }
    private void TrackingScene()
    {
        if (trackCurrentScene != currentScene)
        {
            trackCurrentScene = currentScene;
        }
    }
    private static void EndDraw()
    {
        //end screen
        Raylib.DrawText("You didn't get invited to the party", 500, 200, 30, Color.BLACK);
    }

    private void GameDraw()
    {
        bCharacter.OutOfBounds(bCharacter);
        //game graphics
        DrawEnvironment();
        pCharacter.DrawHp(pCName);
        bCharacter.DrawHp(bCName);
        DrawPlayers();
    }

    private void DrawPlayers()
    {
        Raylib.DrawTexture(bCharacter.botCharacter, (int)bCharacter.botPlace.x, (int)bCharacter.botPlace.y, Color.WHITE);
        Raylib.DrawTexture(pCharacter.playerCharacter, (int)pCharacter.playerPlace.x, (int)pCharacter.playerPlace.y, Color.WHITE);
    }

    private void DrawEnvironment()
    {
        Raylib.DrawText(currentScene, 10, 10, 30, Color.BLACK);
        Raylib.DrawTexture(backGround, 0, 0, Color.WHITE);
        Raylib.DrawTexture(groundGrass, 0, 800, Color.WHITE);
    }

    private void SelectionDraw()
    {
        pCharacter.CharacterSelection(p, pBee, pNaughty, pAce, pDuck, pIce, pEdgy, pTokyo, selectedCharacter, currentScene);
        Raylib.DrawTexture(bCharacter.botCharacter, 1810, 10, Color.WHITE);
    }

    private void StartDraw()
    {
        //start screen
        Raylib.DrawTexture(startBG, 0, 0, Color.WHITE);
        Raylib.DrawText("Q to see controls", 400, 50, 60, Color.WHITE);
    }

    private void Game()
    {
        pCharacter.Restart(pSecret, pCharacter, bCharacter, player, bot, ref currentScene, ref isJumping, ref isCrouching, ref isPunching, ref isLookingRight, ref isLookingLeft, ref punchHit);
        bCharacter.Retreat(pCharacter, bCharacter);
        ResetingPunch();
        ResetingBotPunch();
        pCharacter.LoadCharacter(pCharacter, bCharacter, player, isJumping, isCrouching, ref isPunching, isLookingRight, isLookingLeft, ref loadCharacter, ref punchHit, generator);
        bCharacter.LoadCharacter(pCharacter, bCharacter, bot);
        bCharacter.LeftRight(pCharacter, bCharacter);
        //Bot Jump
        bCharacter.Jumping(bCharacter, pCharacter);
        //jumpbutton
        Jumping();
        //moving to the left
        Direction();
        Movement();
        Crouching();
        Boundries();
        PunchCooldown();
        Attacking();
        punchHit = pCharacter.KnockBack(pCharacter, bCharacter, ground, isLookingRight, punchHit);
        BotPunchCooldown();
        BotAttackLeft();
        BotAttackRight();
        KnockBack();
        Punching();
        Ending();
    }

    private void BotAttackRight()
    {
        if (pCharacter.playerPlace.x <= bCharacter.botPlace.x + bCharacter.botCharacter.width + 20 && isLookingLeft == 1 && bCharacter.looking == Bot.Direction.right)
        {
            if (bCharacter.punchCooldown >= bCharacter.punchCooldownMax)
            {
                bCharacter.AttackRight(pCharacter, bCharacter, generator);
                bCharacter.punchCooldown = 0;
            }
        }
    }

    private void BotAttackLeft()
    {
        //Bot attack
        if (pCharacter.playerPlace.x >= bCharacter.botPlace.x - bCharacter.botCharacter.width - 20 && isLookingRight == 1 && bCharacter.looking == Bot.Direction.left && bCharacter.punchCooldown >= bCharacter.punchCooldownMax)
        {
            if (bCharacter.punchCooldown >= bCharacter.punchCooldownMax)
            {
                bCharacter.AttackLeft(pCharacter, bCharacter, generator);
                bCharacter.punchCooldown = 0;
            }
        }
    }

    private void BotPunchCooldown()
    {
        if (bCharacter.punchCooldown <= bCharacter.punchCooldownMax)
        {
            bCharacter.punchCooldown += Raylib.GetFrameTime();
        }
    }

    private void Attacking()
    {
        //punching
        if (punchHit == 1)
        {
            bCharacter.botPlace.x -= pCharacter.knockback;
            pCharacter.knockback -= 0.5f;
            if (pCharacter.knockback <= 0)
            {
                punchHit = 0;
                pCharacter.knockback = generator.Next((int)pCharacter.knockbackMin, (int)pCharacter.knockbackMax);
            }
            if (bCharacter.botPlace.x <= 0)
            {
                bCharacter.botPlace.x = 0;
            }
        }
    }

    private void PunchCooldown()
    {
        //punchcooldown
        if (pCharacter.punchCooldown < pCharacter.punchCooldownMax)
        {
            pCharacter.punchCooldown += Raylib.GetFrameTime();
        }
    }

    private void Boundries()
    {
        //can't go outside the left wall
        if (pCharacter.playerPlace.x < 0)
        {
            pCharacter.playerPlace.x = 0;
        }
        //can't go outside the right wall
        if (pCharacter.playerPlace.x > 1920 - pCharacter.playerPlace.width)
        {
            pCharacter.playerPlace.x = 1920 - pCharacter.playerPlace.width;
        }
    }

    private void Direction()
    {
        DirectionRight();
        DirectionLeft();
    }

    private void DirectionRight()
    {
        if (pCharacter.playerPlace.x < bCharacter.botPlace.x && isLookingRight == 0 && isPunching == 0 && isJumping == 0)
        {
            isLookingRight = 1;
            isLookingLeft = 0;
            loadCharacter = 1;
        }
    }

    private void DirectionLeft()
    {
        if (pCharacter.playerPlace.x > bCharacter.botPlace.x && isLookingLeft == 0 && isPunching == 0 && isJumping == 0)
        {
            isLookingRight = 0;
            isLookingLeft = 1;
            loadCharacter = 1;
        }
    }

    private void Jumping()
    {
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_W) && isPunching == 0 || Raylib.IsKeyDown(KeyboardKey.KEY_W) && isJumping == 0 && isPunching == 0)
        {
            isJumping = 1;
            //Load Character Sprite
            loadCharacter = 1;
        }
        if (isJumping == 1)
        {
            //jumping
            if (isJumping == 1)
            {
                pCharacter.playerPlace.y -= pCharacter.jumpPower;
                pCharacter.jumpPower -= 0.35f;
            }
            //if you reach the ground
            if (pCharacter.playerPlace.y >= pCharacter.pYMax)
            {
                isJumping = 0;
                //Load Character Sprite
                loadCharacter = 1;
                pCharacter.playerPlace.y = pCharacter.pYMax;
                pCharacter.jumpPower = generator.Next((int)pCharacter.jumpPowerMin, (int)pCharacter.jumpPowerMax);
                if (isPunching == 1)
                {
                    isPunching = 0;
                }
            }
        }
    }

    private void ResetingBotPunch()
    {
        if (bCharacter.punchCooldown >= bCharacter.punchCooldownMax - bCharacter.punchCooldownMax / 4 && bCharacter.botIsPunching == 1)
        {
            bCharacter.botIsPunching = 0;
            if (bCharacter.looking == Bot.Direction.left && bCharacter.botIsJumping == 0)
            {
                bCharacter.botPlace.x += 100;
            }
            else if (bCharacter.looking == Bot.Direction.left && bCharacter.botIsJumping == 1)
            {
                bCharacter.botPlace.x += 50;
            }
            bCharacter.loadBotCharacter = 1;
        }
    }

    private void ResetingPunch()
    {
        if (isLookingLeft == 1 && pCharacter.punchCooldown >= pCharacter.punchCooldownMax - pCharacter.punchCooldownMax / 4 && isPunching == 1 && isJumping == 0)
        {
            pCharacter.playerPlace.x += pCharacter.punchingLeftXPunch;
            isPunching = 0;
            loadCharacter = 1;
        }
        if (isLookingLeft == 1 && pCharacter.punchCooldown >= pCharacter.punchCooldownMax - pCharacter.punchCooldownMax / 4 && isPunching == 1 && isJumping == 1)
        {
            pCharacter.playerPlace.x += pCharacter.punchingLeftXJumpPunch;
            isPunching = 0;
            loadCharacter = 1;
        }
        if (isLookingRight == 1 && pCharacter.punchCooldown >= pCharacter.punchCooldownMax - pCharacter.punchCooldownMax / 4 && isPunching == 1 || isLookingRight == 1 && pCharacter.punchCooldown >= pCharacter.punchCooldownMax - pCharacter.punchCooldownMax / 4 && isPunching == 1 && isJumping == 1)
        {
            isPunching = 0;
            loadCharacter = 1;
        }
    }

    private void Movement()
    {
        if (Raylib.IsKeyDown(KeyboardKey.KEY_A) && isPunching == 0 || Raylib.IsKeyDown(KeyboardKey.KEY_A) && isJumping == 1)
        {
            pCharacter.MoveLeft(p);
        }
        //moving to the right
        if (Raylib.IsKeyDown(KeyboardKey.KEY_D) && isPunching == 0 || Raylib.IsKeyDown(KeyboardKey.KEY_D) && isJumping == 1)
        {
            pCharacter.MoveRight(p);
        }
    }

    private void Crouching()
    {
        //crouching
        if (Raylib.IsKeyDown(KeyboardKey.KEY_S) && isJumping != 1 && isPunching == 0 && pCharacter.canCrouch == 1)
        {
            pCharacter.playerPlace.height = pCharacter.playerCharacter.height / 2;
            pCharacter.playerPlace.y = pCharacter.pYMax + pCharacter.playerPlace.height / 2;
            isCrouching = 1;
        }
        else if (Raylib.IsKeyDown(KeyboardKey.KEY_S) == false && isCrouching == 1)
        {
            //not crouching anymore
            pCharacter.playerPlace.height = pCharacter.playerCharacter.height;
            pCharacter.playerPlace.y = pCharacter.pYMax;
            isCrouching = 0;
        }
    }

    private void KnockBack()
    {
        if (bCharacter.botHit == 1 && bCharacter.looking == Bot.Direction.left && pCharacter.knockbackImmunity == 0)
        {
            pCharacter.playerPlace.x -= bCharacter.knockback;
            bCharacter.knockback -= 0.5f;
            if (bCharacter.knockback <= 0)
            {
                bCharacter.botHit = 0;
                bCharacter.knockback = bCharacter.knockbackMax;
            }
            if (pCharacter.playerPlace.x >= ground.width - 180)
            {
                pCharacter.playerPlace.x = ground.width - 180;
            }
        }
        if (bCharacter.botHit == 1 && bCharacter.looking == Bot.Direction.right && pCharacter.knockbackImmunity == 0)
        {
            pCharacter.playerPlace.x += bCharacter.knockback;
            bCharacter.knockback -= 0.5f;
            if (bCharacter.knockback <= 0)
            {
                bCharacter.botHit = 0;
                bCharacter.knockback = bCharacter.knockbackMax;
            }
            if (pCharacter.playerPlace.x >= ground.width - 180)
            {
                pCharacter.playerPlace.x = ground.width - 180;
            }
        }
    }

    private void Punching()
    {
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_J) && pCharacter.punchCooldown >= pCharacter.punchCooldownMax)
        {
            isPunching = 1;
            //Load Character Sprite
            loadCharacter = 1;
            pCharacter.punchCooldown = 0;
        }
        //punching right
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_L) && pCharacter.punchCooldown >= pCharacter.punchCooldownMax)
        {
            isPunching = 1;
            //Load Character Sprite
            loadCharacter = 1;
            pCharacter.punchCooldown = 0;
        }
    }

    private void Ending()
    {
        if (bCharacter.hp < 0)
        {
            currentScene = "victory";
        }
        if (pCharacter.hp < 0)
        {
            currentScene = "end";
        }
    }

    private void Selection()
    {
        if (bCharacter.botChoice == 0)
        {
            BotSelecting();
        }
        //select character
        if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT) || Raylib.IsKeyPressed(KeyboardKey.KEY_LEFT))
        {
            SelectingLeft();
        }
        if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_RIGHT) || Raylib.IsKeyPressed(KeyboardKey.KEY_RIGHT))
        {
            SelectingRight();
        }
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
        {
            Characters();
            currentScene = "game";
        }
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_LEFT_SHIFT) && Raylib.IsKeyDown(KeyboardKey.KEY_SPACE))
        {
            Secret();
        }
        bCharacter.hp = bCharacter.hpMax;
        pCharacter.hp = pCharacter.hpMax;
        loadCharacter = 1;
        bCharacter.loadBotCharacter = 1;
    }

    private void Secret()
    {
        pCharacter = pSecret;
        player = "SecretCharacter";
        pCName = "Jesus Bezos, Our Lord and Saviour";
        bCharacter.BotsCharacter(b, bAce, bBee, bDuck, bNaughty, bIce, bEdgy, bTokyo, ref bCharacter, ref bot, bCharacter.botChoice);
        currentScene = "game";
    }

    private void Characters()
    {
        if (selectedCharacter == 1)
        {
            pCharacter = p;
            player = "AverageMan";
            pCName = "Average Man";
        }
        else if (selectedCharacter == 2)
        {
            pCharacter = pAce;
            player = "JackOfAllTrades";
            pCName = "Jack Of All Trades";
        }
        else if (selectedCharacter == 3)
        {
            pCharacter = pIce;
            player = "ChillBro";
            pCName = "Chill Bro";
        }
        else if (selectedCharacter == 4)
        {
            pCharacter = pEdgy;
            player = "PhantomBuckaroo";
            pCName = "Phantom Buckaroo";
        }
        else if (selectedCharacter == 5)
        {
            pCharacter = pDuck;
            player = "GeneralDuckington";
            pCName = "General Duckington";
        }
        else if (selectedCharacter == 6)
        {
            pCharacter = pTokyo;
            player = "WalmartBruceLee";
            pCName = "Walmart Bruce Lee";
        }
        else if (selectedCharacter == 7)
        {
            pCharacter = pBee;
            player = "HonkBee";
            pCName = "Honk Bee";
        }
        else if (selectedCharacter == 8)
        {
            pCharacter = pNaughty;
            player = "NaughtySmasher";
            pCName = "Naughty Smasher";
        }
    }

    private void BotSelecting()
    {
        bCharacter.botChoice = generator.Next(1, 9);
        bCharacter.BotsCharacter(b, bAce, bBee, bDuck, bNaughty, bIce, bEdgy, bTokyo, ref bCharacter, ref bot, bCharacter.botChoice);
    }

    private void SelectingRight()
    {
        selectedCharacter += 1;
        if (selectedCharacter > 8)
        {
            selectedCharacter = 1;
        }
    }

    private void SelectingLeft()
    {
        selectedCharacter -= 1;
        if (selectedCharacter < 1)
        {
            selectedCharacter = 8;
        }
    }

    private void Start()
    {
        //start the game
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
        {
            currentScene = "selection";
        }
    }
}
