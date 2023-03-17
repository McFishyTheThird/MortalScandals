using Raylib_cs;
Raylib.InitWindow(1920, 1000, "Mortal Scandals");
Raylib.SetTargetFPS(100);
Raylib.InitAudioDevice();
Random generator = new Random();
//character and bot variables
Texture2D startBG = Raylib.LoadTexture("StartBG.png");
Texture2D backGround = Raylib.LoadTexture("BG.png");
Texture2D groundDirt = Raylib.LoadTexture("GroundDirt.png");
Texture2D groundGrass = Raylib.LoadTexture("Ground.png");
Player p = new Player();
Player pIce = new Player();
Player pEdgy = new Player();
Player pTokyo = new Player();
Player pAce = new Player();
Player pDuck = new Player();
Player pSecret = new Player();
Bot b = new Bot();
Bot bIce = new Bot();
Bot bEdgy = new Bot();
Bot bTokyo = new Bot();
Bot bAce = new Bot();
Bot bDuck = new Bot();
Player pCharacter = new Player();
Bot bCharacter = new Bot();
//ground
string pCName = "Average Man";
string bCName = "Average Man";
Rectangle ground = new Rectangle(0, 800, 2000, 200);
Rectangle characterSelect = new Rectangle(0,0,0,0);
int selectedCharacter = 1;
//player stats
Rectangle hpBG = new Rectangle(240, 100, 450, 50);
Rectangle hpBGBot = new Rectangle(1390, 100, 300, 50);
string player = "AverageMan";
string bot = "AverageMan";
//Average Man Stats
p.playerCharacter = Raylib.LoadTexture($"AverageMan/CharacterRight.png");
p.playerPlace = new Rectangle(0, 600, 100, 200);
p.pYMax = 600;
p.jumpPower = 15;
p.jumpPowerMax = 16;
p.jumpPowerMin = 15;
p.hpMax = 800;
p.speed = 5;
p.punchDamageMax = 51;
p.punchDamageMin = 50;
p.punchCooldown = 0.5f;
p.punchCooldownMax = 0.5f;
p.knockback = 20;
p.knockbackMax = 21; 
p.knockbackMin = 20; 
p.knockbackImmunity = 0;
p.canCrouch = 1;
//Chill Bro Stats
pIce.playerCharacter = Raylib.LoadTexture($"ChillBro/CharacterRight.png");
pIce.playerPlace = new Rectangle(0, 600, 100, 200);
pIce.pYMax = 600;
pIce.jumpPower = 0;
pIce.jumpPowerMax = 1;
pIce.jumpPowerMin = 0;
pIce.hpMax = 750;
pIce.speed = 10;
pIce.punchDamageMax = 81;
pIce.punchDamageMin = 80;
pIce.punchCooldown = 1f;
pIce.punchCooldownMax = 1f;
pIce.knockback = 30;
pIce.knockbackMax = 31;
pIce.knockbackMin = 30;
pIce.knockbackImmunity = 0;
pIce.canCrouch = 1;
//Phantom Buckaroo Stats
pEdgy.playerCharacter = Raylib.LoadTexture($"PhantomBuckaroo/CharacterRight.png");
pEdgy.playerPlace = new Rectangle(0, 600, 100, 200);
pEdgy.pYMax = 600;
pEdgy.jumpPower = 15;
pEdgy.jumpPowerMax = 16;
pEdgy.jumpPowerMin = 15;
pEdgy.hpMax = 800;
pEdgy.speed = 5;
pEdgy.punchDamageMax = 61;
pEdgy.punchDamageMin = 60;
pEdgy.punchCooldown = 0.4f;
pEdgy.punchCooldownMax = 0.4f;
pEdgy.knockback = 25;
pEdgy.knockbackMax = 26;
pEdgy.knockbackMin = 25;
pEdgy.knockbackImmunity = 0;
pEdgy.canCrouch = 0;
//Walmart Bruce Lee Stats
pTokyo.playerCharacter = Raylib.LoadTexture($"WalmartBruceLee/CharacterRight.png");
pTokyo.playerPlace = new Rectangle(0, 600, 100, 200);
pTokyo.pYMax = 600;
pTokyo.jumpPower = 20;
pTokyo.jumpPowerMax = 21;
pTokyo.jumpPowerMin = 20;
pTokyo.hpMax = 600;
pTokyo.speed = 13;
pTokyo.punchDamageMax = 31;
pTokyo.punchDamageMin = 30;
pTokyo.punchCooldown = 0.2f;
pTokyo.punchCooldownMax = 0.2f;
pTokyo.knockback = 10;
pTokyo.knockbackMax = 11;
pTokyo.knockbackMin = 10;
pTokyo.knockbackImmunity = 0;
pTokyo.canCrouch = 1;
//Jack Of All Trades Stats
pAce.playerCharacter = Raylib.LoadTexture($"JackOfAllTrades/CharacterRight.png");
pAce.playerPlace = new Rectangle(0, 588, 100, 200);
pAce.pYMax = 588;
pAce.jumpPower = 20;
pAce.jumpPowerMax = 21;
pAce.jumpPowerMin = 2;
pAce.hpMax = 600;
pAce.speed = 7;
pAce.punchDamageMax = 121;
pAce.punchDamageMin = 10;
pAce.punchCooldown = 0.75f;
pAce.punchCooldownMax = 0.75f;
pAce.knockback = 10;
pAce.knockbackMax = 25;
pAce.knockbackMin = 0;
pAce.knockbackImmunity = 0;
pAce.canCrouch = 1;
//General Duckington Stats
pDuck.playerCharacter = Raylib.LoadTexture($"GeneralDuckington/CharacterRight.png");
pDuck.playerPlace = new Rectangle(0, 600, 100, 200);
pDuck.pYMax = 600;
pDuck.jumpPower = 10;
pDuck.jumpPowerMax = 13;
pDuck.jumpPowerMin = 10;
pDuck.hpMax = 600;
pDuck.speed = 5;
pDuck.punchDamageMax = 80;
pDuck.punchDamageMin = 80;
pDuck.punchCooldown = 0.75f;
pDuck.punchCooldownMax = 0.75f;
pDuck.knockback = 10;
pDuck.knockbackMax = 31;
pDuck.knockbackMin = 30;
pDuck.knockbackImmunity = 0;
pDuck.canCrouch = 1;
//Secret
pSecret.playerCharacter = Raylib.LoadTexture($"SecretCharacter/CharacterRight.png");
pSecret.playerPlace = new Rectangle(0, 398, 100, 200);
pSecret.pYMax = 398;
pSecret.jumpPower = 2;
pSecret.jumpPowerMax = 2;
pSecret.hpMax = 1200;
pSecret.speed = 3;
pSecret.punchDamageMin = 69;
pSecret.punchDamageMax = 421;
pSecret.punchCooldown = 0.1f;
pSecret.punchCooldownMax = 0.1f;
pSecret.knockback = 5;
pSecret.knockbackMax = 5;
pSecret.knockbackImmunity = 1;
pSecret.canCrouch = 0;
//bot stats
b.botCharacter = Raylib.LoadTexture($"AverageMan/CharacterLeft.png");
b.jumpPower = 15;
b.jumpPowerMax = 15;
b.hpMax = 800;
b.speed = 5;
b.punchDamage = 50;
b.punchCooldown = 0.5f;
b.punchCooldownMax = 0.5f;
b.knockback = 15;
b.knockbackMax = 15;
//Bot IceDude
bIce.botCharacter = Raylib.LoadTexture($"ChillBro/CharacterLeft.png");
bIce.jumpPower = 0;
bIce.jumpPowerMax = 0;
bIce.hpMax = 750;
bIce.speed = 10;
bIce.punchDamage = 80;
bIce.punchCooldown = 1f;
bIce.punchCooldownMax = 1f;
bIce.knockback = 30;
bIce.knockbackMax = 30;
//Bot Phantom Buckaroo
bEdgy.botCharacter = Raylib.LoadTexture($"PhantomBuckaroo/CharacterLeft.png");
bEdgy.jumpPower = 15;
bEdgy.jumpPowerMax = 15;
bEdgy.hpMax = 850;
bEdgy.speed = 5;
bEdgy.punchDamage = 60;
bEdgy.punchCooldown = 0.4f;
bEdgy.punchCooldownMax = 0.4f;
bEdgy.knockback = 15;
bEdgy.knockbackMax = 25;
//bot WalmartMartialArtsDude
bTokyo.botCharacter = Raylib.LoadTexture($"WalmartBruceLee/CharacterLeft.png");
bTokyo.jumpPower = 20;
bTokyo.jumpPowerMax = 20;
bTokyo.hpMax = 600;
bTokyo.speed = 13;
bTokyo.punchDamage = 30;
bTokyo.punchCooldown = 0.2f;
bTokyo.punchCooldownMax = 0.2f;
bTokyo.knockback = 10;
bTokyo.knockbackMax = 10;
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
//currentscene game/start/end/victory/selection
while (Raylib.WindowShouldClose() == false)
{
    if (currentScene == "start")
    {
        //start the game
        if(Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
        {
            currentScene = "selection";
        }

    }
    else if(currentScene == "selection")
    {
        if(bCharacter.botChoice == 0)
        {
            bCharacter.botChoice = generator.Next(1,5);
            bCharacter.BotsCharacter(b, bAce, bIce, bEdgy, bTokyo, ref bCharacter, ref bot, bCharacter.botChoice);
        }
        //select character
        if(Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT) || Raylib.IsKeyPressed(KeyboardKey.KEY_LEFT))
        {
            selectedCharacter -= 1;
            if(selectedCharacter < 1)
            {
                selectedCharacter = 6;
            }
        }
        if(Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_RIGHT) || Raylib.IsKeyPressed(KeyboardKey.KEY_RIGHT))
        {
            selectedCharacter += 1;
            if(selectedCharacter > 6)
            {
                selectedCharacter = 1;
            }
        }
        if(Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
        {
            if (selectedCharacter == 1)
            {
                pCharacter = p;
                player = "AverageMan";
                pCName = "Average Man";
            }
            if (selectedCharacter == 2)
            {
                pCharacter = pAce;
                player = "JackOfAllTrades";
                pCName = "Jack Of All Trades";
            }
            if (selectedCharacter == 3)
            {
                pCharacter = pIce;
                player = "ChillBro";
                pCName = "Chill Bro";
            }
            if (selectedCharacter == 4)
            {
                pCharacter = pEdgy;
                player = "PhantomBuckaroo";
                pCName = "Phantom Buckaroo";
            }
            if (selectedCharacter == 5)
            {
                pCharacter = pDuck;
                player = "GeneralDuckington";
                pCName = "General Duckington";
            }
            if (selectedCharacter == 6)
            {
                pCharacter = pTokyo;
                player = "WalmartBruceLee";
                pCName = "Walmart Bruce Lee";
            }
            currentScene = "game";
        }
        if(Raylib.IsKeyPressed(KeyboardKey.KEY_LEFT_SHIFT) && Raylib.IsKeyDown(KeyboardKey.KEY_SPACE))
        {
            pCharacter = pSecret;
            player = "SecretCharacter";
            bCharacter.BotsCharacter(b, bAce, bIce, bEdgy, bTokyo, ref bCharacter, ref bot, bCharacter.botChoice);
            currentScene = "game";
        }
        bCharacter.hp = bCharacter.hpMax;
        pCharacter.hp = pCharacter.hpMax;
        loadCharacter = 1;
        bCharacter.loadBotCharacter = 1;
    }
    else if(currentScene == "game")
    {
        if(Raylib.IsKeyPressed(KeyboardKey.KEY_TAB))
        {
            pCharacter.Reset(pSecret, pCharacter, out isJumping, out isCrouching, out isPunching, out isLookingRight, out isLookingLeft, out punchHit, player);
            bCharacter.Reset(bCharacter, bot);
            currentScene = "start";
        }
        bCharacter.Retreat(pCharacter, bCharacter);
        if (isLookingLeft == 1 && pCharacter.punchCooldown >= pCharacter.punchCooldownMax - pCharacter.punchCooldownMax / 4 && isPunching == 1 && isJumping == 0)
        {
            pCharacter.playerPlace.x += 100;
            isPunching = 0;
            loadCharacter = 1;
        }
        if (isLookingLeft == 1 && pCharacter.punchCooldown >= pCharacter.punchCooldownMax - pCharacter.punchCooldownMax / 4 && isPunching == 1 && isJumping == 1)
        {
            Console.WriteLine("w");
            pCharacter.playerPlace.x += 50;
            isPunching = 0;
            loadCharacter = 1;
        }
        if (isLookingRight == 1 && pCharacter.punchCooldown >= pCharacter.punchCooldownMax - pCharacter.punchCooldownMax / 4 && isPunching == 1 || isLookingRight == 1 && pCharacter.punchCooldown >= pCharacter.punchCooldownMax - pCharacter.punchCooldownMax / 4 && isPunching == 1 && isJumping == 1)
        {
            isPunching = 0;
            loadCharacter = 1;
        }
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
        pCharacter.LoadCharacter(pCharacter, bCharacter, player, isJumping, isCrouching, ref isPunching, isLookingRight, isLookingLeft, ref loadCharacter, ref punchHit, generator);
        bCharacter.LoadCharacter(pCharacter, bCharacter, bot);
        bCharacter.LeftRight(pCharacter, bCharacter);
        //Bot Jump
        bCharacter.Jumping(bCharacter, pCharacter);
        //jumpbutton
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
                if(isPunching == 1)
                {
                    isPunching = 0;
                }
            }
        }
        //moving to the left
        if (pCharacter.playerPlace.x < bCharacter.botPlace.x && isLookingRight == 0 && isPunching == 0 && isJumping == 0)
        {
            isLookingRight = 1;
            isLookingLeft = 0;
            loadCharacter = 1;
        }
        if (pCharacter.playerPlace.x > bCharacter.botPlace.x && isLookingLeft == 0 && isPunching == 0 && isJumping == 0)
        {
            isLookingRight = 0;
            isLookingLeft = 1;
            loadCharacter = 1;
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_A) && isPunching == 0 || Raylib.IsKeyDown(KeyboardKey.KEY_A) && isJumping == 1)
        {
            pCharacter.MoveLeft(p);
        }
        //moving to the right
        if (Raylib.IsKeyDown(KeyboardKey.KEY_D) && isPunching == 0 || Raylib.IsKeyDown(KeyboardKey.KEY_D) && isJumping == 1)
        {
            pCharacter.MoveRight(p);
        }
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
        //punchcooldown
        if (pCharacter.punchCooldown < pCharacter.punchCooldownMax)
        {
            pCharacter.punchCooldown += Raylib.GetFrameTime();
        }
        //punching left
        if (punchHit == 1 && isLookingLeft == 1)
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
        punchHit = pCharacter.KnockBack(pCharacter, bCharacter, ground, isLookingRight, punchHit);
        if (bCharacter.punchCooldown <= bCharacter.punchCooldownMax)
        {
            bCharacter.punchCooldown += Raylib.GetFrameTime();
        }
        //Bot attack
        if (pCharacter.playerPlace.x >= bCharacter.botPlace.x - bCharacter.botCharacter.width - 20 && isLookingRight == 1 && bCharacter.looking == Bot.Direction.left && bCharacter.punchCooldown >= bCharacter.punchCooldownMax)
        {
            if (bCharacter.punchCooldown >= bCharacter.punchCooldownMax)
            {
                bCharacter.AttackLeft(pCharacter, bCharacter, generator);
                bCharacter.punchCooldown = 0;
            }
        }
        if (pCharacter.playerPlace.x <= bCharacter.botPlace.x + bCharacter.botCharacter.width + 20 && isLookingLeft == 1 && bCharacter.looking == Bot.Direction.right)
        {
            if (bCharacter.punchCooldown >= bCharacter.punchCooldownMax)
            {
                bCharacter.AttackRight(pCharacter, bCharacter, generator);
                bCharacter.punchCooldown = 0;
            }
        }
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
    else if(currentScene == "end")
    {
        //end scene
    }
    else if(currentScene == "victory")
    {
        //victory
    }
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.WHITE);
    //graphics
    if(currentScene == "start")
    {
        //start screen
        Raylib.DrawTexture(startBG, 0, 0, Color.WHITE);
    }
    else if(currentScene == "selection")
    {
        pCharacter.CharacterSelection(p, pAce, pDuck, pIce, pEdgy, pTokyo, selectedCharacter, currentScene);
        Raylib.DrawTexture(bCharacter.botCharacter, 1810, 10, Color.WHITE);
    }
    else if(currentScene == "game")
    {
        bCharacter.OutOfBounds(bCharacter);
        //game graphics
        Raylib.DrawText(currentScene, 10,10, 30, Color.BLACK);
        Raylib.DrawTexture(backGround, 0,0,Color.WHITE);
        Raylib.DrawTexture(groundGrass, 0,800,Color.WHITE);
        Raylib.DrawRectangleRec(hpBGBot, Color.WHITE);
        pCharacter.DrawHp(pCName, hpBG);
        bCharacter.DrawHp(bCName);
        Raylib.DrawTexture(bCharacter.botCharacter, (int)bCharacter.botPlace.x, (int)bCharacter.botPlace.y,Color.WHITE);
        Raylib.DrawTexture(pCharacter.playerCharacter, (int)pCharacter.playerPlace.x, (int)pCharacter.playerPlace.y,Color.WHITE);
    }
    else if(currentScene == "end")
    {
        //end screen
        Raylib.DrawText(currentScene, 10,10, 30, Color.BLACK);
    }
    else if(currentScene == "victory")
    {
        //victory screen
        Raylib.DrawText(currentScene, 10,10, 30, Color.BLACK);
    }
    Raylib.EndDrawing();
}