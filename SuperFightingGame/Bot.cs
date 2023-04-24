using Raylib_cs;

public class Bot
{
    public Rectangle botPlace;
    public int botChoice = 0;
    public int bYMax = 0;
    public string bCName;
    int running = 0;
    public Texture2D botCharacter;
    public float speed;
    public int hp;
    public int hpMax;
    public int punchDamageMax;
    public int punchDamageMin;
    public float knockback;
    public float knockbackMax;
    public float knockbackMin;
    public float punchCooldown;
    public float punchCooldownMax;
    public float jumpPower;
    public float jumpPowerMax;
    public float jumpPowerMin;
    public float punchingLeftXPunch;
    public float punchingLeftXJumpPunch;
    public int loadBotCharacter = 0;
    public int botIsJumping = 0;
    public int botIsCrouching = 0;
    public int botIsPunching = 0;
    public int botHit = 0;
    int run;
    int jump;
    float timer;
    Random generator = new Random();

    public enum Direction { left, right };

    public Direction looking = Direction.right;

    public void OutOfBounds(Bot bCharacter)
    {
        if (bCharacter.botPlace.x <= 0)
        {
            bCharacter.botPlace.x = 0;
        }
        if (bCharacter.botPlace.x >= 1820)
        {
            bCharacter.botPlace.x = 1820;
        }
    }
    public void Reset(Bot bCharacter, string bot)
    {
        botIsJumping = 0;
        botIsPunching = 0;
        looking = Direction.left;
        botHit = 0;
        bCharacter.botCharacter = Raylib.LoadTexture($"{bot}/CharacterLeft.png");
        botChoice = 0;
    }
    //Drawing health
    public void DrawHp(string bCName)
    {
        //ändra plats till bot hp bar
        Raylib.DrawText($"{bCName}: {hp} hp", 1400, 110, 30, Color.BLACK);
    }
    //Moving bot towards player
    public void Move(Player pCharacter, Bot bCharacter)
    {
        //Moving bot right
        if (pCharacter.playerPlace.x > bCharacter.botPlace.x + 100)
        {
            bCharacter.botPlace.x += speed;
        }
        else if (pCharacter.playerPlace.x < bCharacter.botPlace.x - 100)
        {
            //Moving bot left
            bCharacter.botPlace.x -= speed;
        }
    }
    //Escaping when on low hp(determined by randomiser if it retreats or not)
    public void Retreat(Player pCharacter, Bot bCharacter)
    {
        Timer();
        DirectionChoice();
        RunningChoice();
        if (running == 1)
        {
            RunningAway(pCharacter, bCharacter);
        }
        else if (running == 0)
        {
            Move(pCharacter, bCharacter);
        }
        //Keeping the bot from escaping
        //it stops a little before the actual edge of the screen so that it might be able to escape if the player moves all the way to the edge
        BotBarriers(bCharacter);
    }

    private static void BotBarriers(Bot bCharacter)
    {
        if (bCharacter.botPlace.x >= 1820)
        {
            bCharacter.botPlace.x = 1820;
        }
        else if (bCharacter.botPlace.x <= 0)
        {
            bCharacter.botPlace.x = 0;
        }
    }

    private void RunningAway(Player pCharacter, Bot bCharacter)
    {
        //moving away from the player depending on which side the player is on
        if (pCharacter.playerPlace.x > bCharacter.botPlace.x + 100)
        {
            bCharacter.botPlace.x -= speed;
        }
        else if (pCharacter.playerPlace.x < bCharacter.botPlace.x - 100)
        {
            bCharacter.botPlace.x += speed;
        }
    }

    private void RunningChoice()
    {
        if (run == 1)
        {
            Choice1();
        }
        else if (run == 2)
        {
            Choice2();
        }
        else if (run == 3)
        {
            Choice3();
        }
    }

    private void Choice3()
    {
        running = 2;
        run = 0;
        ResetTimer3();
    }

    private void Choice2()
    {
        running = 0;
        run = 0;
        ResetTimer2();
    }

    private void Choice1()
    {
        running = 1;
        run = 0;
        ResetTimer1();
    }

    private void ResetTimer3()
    {
        if (timer >= 3)
        {
            timer = 2.5f;
        }
    }

    private void ResetTimer2()
    {
        if (timer >= 3)
        {
            timer = generator.Next(0, 2);
        }
    }

    private void ResetTimer1()
    {
        if (timer >= 3)
        {
            timer = generator.Next(1, 3);
        }
    }

    private void DirectionChoice()
    {
        if (timer >= 3)
        {
            run = generator.Next(1, 4);
        }
    }

    private void Timer()
    {
        if (timer <= 3)
        {
            timer += Raylib.GetFrameTime();
        }
    }

    //Jumping
    public void Jumping(Bot bCharacter, Player pCharacter)
    {
        if (pCharacter.playerPlace.y < pCharacter.pYMax)
        {
            jump = generator.Next(1, 100);
        }
        else
        {
            jump = generator.Next(1, 500);
        }
        if (jump < 10 && botIsJumping == 0 && botIsPunching == 0)
        {
            botIsJumping = 1;
            //Load Character Sprite
            loadBotCharacter = 1;
        }
        if (botIsJumping == 1)
        {
            //jumping
            if (botIsJumping == 1)
            {
                bCharacter.botPlace.y -= bCharacter.jumpPower;
                bCharacter.jumpPower -= 0.35f;
            }
            //if you reach the ground
            if (bCharacter.botPlace.y >= 600)
            {
                botIsJumping = 0;
                //Load Character Sprite
                loadBotCharacter = 1;
                bCharacter.botPlace.y = bCharacter.bYMax;
                bCharacter.jumpPower = bCharacter.jumpPowerMax;
                if (botIsPunching == 1)
                {
                    botIsPunching = 0;
                }
            }
        }
    }
    //attacking the player
    public void AttackLeft(Player pCharacter, Bot bCharacter, Random generator)
    {
        botIsPunching = 1;
        loadBotCharacter = 1;
        looking = Direction.left;
    }
    public void AttackRight(Player pCharacter, Bot bCharacter, Random generator)
    {
        botIsPunching = 1;
        loadBotCharacter = 1;
        looking = Direction.right;
    }
    //changing the direction the bot is looking
    public void LeftRight(Player pCharacter, Bot bCharacter)
    {
        //looking right
        if (bCharacter.botPlace.x < pCharacter.playerPlace.x && looking == Direction.left && botIsPunching == 0 && botIsJumping == 0)
        {
            loadBotCharacter = 1;
            looking = Direction.right;
        }
        //looking left
        if (bCharacter.botPlace.x > pCharacter.playerPlace.x && looking == Direction.right && botIsPunching == 0 && botIsJumping == 0)
        {
            looking = Direction.left;
            loadBotCharacter = 1;
        }
    }
    //loading the sprites when something happens
    public void LoadCharacter(Player pCharacter, Bot bCharacter, string bot)
    {
        //all the sprites for looking right
        if (looking == Direction.right && loadBotCharacter == 1)
        {
            RightSprites(pCharacter, bCharacter, bot);
        }
        //Loading the character sprites if the bot is looking left
        if (looking == Direction.left && loadBotCharacter == 1)
        {
            LeftSprites(pCharacter, bCharacter, bot);
        }
        bCharacter.botPlace.width = bCharacter.botCharacter.width;
        bCharacter.botPlace.height = bCharacter.botCharacter.height;
        //no longer loading the sprites for the bot
        loadBotCharacter = 0;
    }

    private void LeftSprites(Player pCharacter, Bot bCharacter, string bot)
    {
        //idle
        if (botIsPunching == 0 && botIsJumping == 0 && botIsCrouching == 0)
        {
            bCharacter.botCharacter = Raylib.LoadTexture($"{bot}/CharacterLeft.png");

        }
        else if (botIsJumping == 1 && botIsPunching == 0)
        {
            //jumping
            bCharacter.botCharacter = Raylib.LoadTexture($"{bot}/CharacterJumpingLeft.png");
        }
        else if (botIsJumping == 1 && botIsPunching == 1)
        {
            //jumping and punching
            bCharacter.botCharacter = Raylib.LoadTexture($"{bot}/CharacterJumpPunchLeft.png");
            bCharacter.botPlace.x -= 50;
            if (Raylib.CheckCollisionRecs(bCharacter.botPlace, pCharacter.playerPlace))
            {
                //if the bot hits the player while punching
                pCharacter.hp -= generator.Next(bCharacter.punchDamageMin, bCharacter.punchDamageMax);
                botHit = 1;
            }
        }
        else if (botIsPunching == 1)
        {
            //if punching
            bCharacter.botCharacter = Raylib.LoadTexture($"{bot}/CharacterPunchingLeft.png");
            //moving it a little bit so it actually punches that way
            bCharacter.botPlace.x -= 100;
            if (Raylib.CheckCollisionRecs(bCharacter.botPlace, pCharacter.playerPlace))
            {
                //if the bot hits the player while punching
                pCharacter.hp -= generator.Next(bCharacter.punchDamageMin, bCharacter.punchDamageMax);
                botHit = 1;
            }
        }
    }

    private void RightSprites(Player pCharacter, Bot bCharacter, string bot)
    {
        //idle
        if (botIsPunching == 0 && botIsJumping == 0 && botIsCrouching == 0)
        {
            bCharacter.botCharacter = Raylib.LoadTexture($"{bot}/CharacterRight.png");
        }
        else if (botIsJumping == 1 && botIsPunching == 0)
        {
            //jumping
            bCharacter.botCharacter = Raylib.LoadTexture($"{bot}/CharacterJumpingRight.png");
        }
        else if (botIsJumping == 1 && botIsPunching == 1)
        {
            //jumping and punching
            bCharacter.botCharacter = Raylib.LoadTexture($"{bot}/CharacterJumpPunchRight.png");
            if (Raylib.CheckCollisionRecs(bCharacter.botPlace, pCharacter.playerPlace))
            {
                //if bot hits the player when punching
                pCharacter.hp -= generator.Next(bCharacter.punchDamageMin, bCharacter.punchDamageMax);
                botHit = 1;
            }
        }
        else if (botIsPunching == 1)
        {
            //just punching on ground
            bCharacter.botCharacter = Raylib.LoadTexture($"{bot}/CharacterPunchingRight.png");
            //Damage for punching
            if (Raylib.CheckCollisionRecs(bCharacter.botPlace, pCharacter.playerPlace))
            {
                //if the bot hits the player while punching
                pCharacter.hp -= generator.Next(bCharacter.punchDamageMin, bCharacter.punchDamageMax);
                botHit = 1;
            }
        }
    }

    public void BotsCharacter(Bot b, Bot bAce, Bot bBee, Bot bDuck, Bot bNaughty, Bot bIce, Bot bEdgy, Bot bTokyo, ref Bot bCharacter, ref string bot, int botChoice)
    {
        if (botChoice == 1)
        {
            bCharacter = b;
            bot = "AverageMan";
            bCName = "Average Man";
            bCharacter.botPlace = new Rectangle(1820, bCharacter.bYMax, 100, 200);
        }
        if (botChoice == 2)
        {
            bCharacter = bIce;
            bot = "ChillBro";
            bCName = "Chill Bro";
            bCharacter.botPlace = new Rectangle(1820, bCharacter.bYMax, 100, 200);
        }
        if (botChoice == 3)
        {
            bCharacter = bEdgy;
            bot = "PhantomBuckaroo";
            bCName = "Phantom Buckaroo";
            bCharacter.botPlace = new Rectangle(1820, bCharacter.bYMax, 100, 200);
        }
        if (botChoice == 4)
        {
            bCharacter = bTokyo;
            bot = "WalmartBruceLee";
            bCName = "Walmart Bruce Lee";
            bCharacter.botPlace = new Rectangle(1820, bCharacter.bYMax, 100, 200);
        }
        if (botChoice == 5)
        {
            bCharacter = bAce;
            bot = "JackOfAllTrades";
            bCName = "Jack Of All Trades";
            bCharacter.botPlace = new Rectangle(1820, bAce.bYMax, 100, 200);
        }
        if (botChoice == 6)
        {
            bCharacter = bBee;
            bot = "HonkBee";
            bCName = "Honk Bee";
            bCharacter.botPlace = new Rectangle(1820, bCharacter.bYMax, 100, 200);
        }
        if (botChoice == 7)
        {
            bCharacter = bDuck;
            bot = "GeneralDuckington";
            bCName = "General Duckington";
            bCharacter.botPlace = new Rectangle(1820, bCharacter.bYMax, 100, 200);
        }
        if (botChoice == 8)
        {
            bCharacter = bNaughty;
            bot = "NaughtySmasher";
            bCName = "Naughty Smasher";
            bCharacter.botPlace = new Rectangle(1820, bNaughty.bYMax, 100, 200);
        }
    }
}
