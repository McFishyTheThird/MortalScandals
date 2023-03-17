using Raylib_cs;

public class Bot
{
    public Rectangle botPlace = new Rectangle(1820, 600, 100, 200);
    public int botChoice = 0;
    int running = 0;
    public Texture2D botCharacter;
    public float speed;
    public int hp;
    public int hpMax;
    public int punchDamage;
    public float knockback;
    public float knockbackMax;
    public float punchCooldown;
    public float punchCooldownMax;
    public float jumpPower;
    public float jumpPowerMax;
    public int loadBotCharacter = 0;
    public int botIsJumping = 0;
    public int botIsCrouching = 0;
    public int botIsPunching = 0;
    public int botHit = 0;
    int run;
    int jump;
    float timer;
    Random generator = new Random();

    public enum Direction {left, right};

    public Direction looking = Direction.right;

    public void OutOfBounds(Bot bCharacter)
    {
        if(bCharacter.botPlace.x <= 0)
        {
            bCharacter.botPlace.x = 0;
        }
        if(bCharacter.botPlace.x >= 1820)
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
        bCharacter.botPlace = new Rectangle(1820, 600, 100, 200);
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
        if(timer <= 3)
        {
            timer += Raylib.GetFrameTime();
        }
        if(timer >= 3)
        {
            run = generator.Next(1, 4);
        }
        if(run == 1)
        {
            running = 1;
            run = 0;
            if(timer >= 3)
            {
                timer = generator.Next(1,3);
            }
        }
        else if(run == 2)
        {
            running = 0;
            run = 0;
            if(timer >= 3)
            {
                timer = generator.Next(0,2);
            }
        }
        else if(run == 3)
        {
            running = 2;
            run = 0;
            if(timer >= 3)
            {
                timer = 2.5f;
            }
        }
        if(running == 1)
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
        else if(running == 0)
        {
            Move(pCharacter, bCharacter);
        }
        //Keeping the bot from escaping
        //it stops a little before the actual edge of the screen so that it might be able to escape if the player moves all the way to the edge
        if(bCharacter.botPlace.x >= 1820)
        {
            bCharacter.botPlace.x = 1820;
        }
        else if(bCharacter.botPlace.x <= 0)
        {
            bCharacter.botPlace.x = 0;
        }
    }
    //Jumping
    public void Jumping(Bot bCharacter, Player pCharacter)
    {
        if(bCharacter.botPlace.y < pCharacter.playerPlace.y)
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
                bCharacter.botPlace.y = 600;
                bCharacter.jumpPower = bCharacter.jumpPowerMax;
                if(botIsPunching == 1)
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
            //idle
            if (botIsPunching == 0 && botIsJumping == 0 && botIsCrouching == 0)
            {
                bCharacter.botCharacter = Raylib.LoadTexture($"{bot}/CharacterRight.png");
                bCharacter.botPlace.width = bCharacter.botCharacter.width;
                bCharacter.botPlace.height = bCharacter.botCharacter.height;
            }
            else if (botIsJumping == 1 && botIsPunching == 0)
            {
                //jumping
                bCharacter.botCharacter = Raylib.LoadTexture($"{bot}/CharacterJumpingRight.png");
                bCharacter.botPlace.width = bCharacter.botCharacter.width;
                bCharacter.botPlace.height = bCharacter.botCharacter.height;
            }
            else if (botIsJumping == 1 && botIsPunching == 1)
            {
                //jumping and punching
                bCharacter.botCharacter = Raylib.LoadTexture($"{bot}/CharacterJumpPunchRight.png");
                bCharacter.botPlace.width = bCharacter.botCharacter.width;
                bCharacter.botPlace.height = bCharacter.botCharacter.height;
                if (Raylib.CheckCollisionRecs(bCharacter.botPlace, pCharacter.playerPlace))
                {
                    //if bot hits the player when punching
                    pCharacter.hp -= bCharacter.punchDamage;
                    botHit = 1;
                }
            }
            else if (botIsPunching == 1)
            {
                //just punching on ground
                bCharacter.botCharacter = Raylib.LoadTexture($"{bot}/CharacterPunchingRight.png");
                bCharacter.botPlace.width = bCharacter.botCharacter.width;
                bCharacter.botPlace.height = bCharacter.botCharacter.height;
                //Damage for punching
                if (Raylib.CheckCollisionRecs(bCharacter.botPlace, pCharacter.playerPlace))
                {
                    //if the bot hits the player while punching
                    pCharacter.hp -= bCharacter.punchDamage;
                    botHit = 1;
                }
            }
            //no longer loading the character
            loadBotCharacter = 0;
        }
        //Loading the character sprites if the bot is looking left
        if (looking == Direction.left && loadBotCharacter == 1)
        {
            //idle
            if (botIsPunching == 0 && botIsJumping == 0 && botIsCrouching == 0)
            {
                bCharacter.botCharacter = Raylib.LoadTexture($"{bot}/CharacterLeft.png");
                bCharacter.botPlace.width = bCharacter.botCharacter.width;
                bCharacter.botPlace.height = bCharacter.botCharacter.height;
            }
            else if (botIsJumping == 1 && botIsPunching == 0)
            {
                //jumping
                bCharacter.botCharacter = Raylib.LoadTexture($"{bot}/CharacterJumpingLeft.png");
                bCharacter.botPlace.width = bCharacter.botCharacter.width;
                bCharacter.botPlace.height = bCharacter.botCharacter.height;
            }
            else if (botIsJumping == 1 && botIsPunching == 1)
            {
                //jumping and punching
                bCharacter.botCharacter = Raylib.LoadTexture($"{bot}/CharacterJumpPunchLeft.png");
                bCharacter.botPlace.width = bCharacter.botCharacter.width;
                bCharacter.botPlace.height = bCharacter.botCharacter.height;
                bCharacter.botPlace.x -= 50;
                if (Raylib.CheckCollisionRecs(bCharacter.botPlace, pCharacter.playerPlace))
                {
                    //if the bot hits the player while punching
                    pCharacter.hp -= bCharacter.punchDamage;
                    botHit = 1;
                }
            }
            else if (botIsPunching == 1)
            {
                //if punching
                bCharacter.botCharacter = Raylib.LoadTexture($"{bot}/CharacterPunchingLeft.png");
                bCharacter.botPlace.width = bCharacter.botCharacter.width;
                bCharacter.botPlace.height = bCharacter.botCharacter.height;
                //moving it a little bit so it actually punches that way
                bCharacter.botPlace.x -= 100;
                if (Raylib.CheckCollisionRecs(bCharacter.botPlace, pCharacter.playerPlace))
                {
                    //if the bot hits the player while punching
                    pCharacter.hp -= bCharacter.punchDamage;
                    botHit = 1;
                }
            }
            //no longer loading the sprites for the bot
            loadBotCharacter = 0;
        }
    }
    public void BotsCharacter(Bot b, Bot bAce, Bot bIce, Bot bEdgy, Bot bTokyo, ref Bot bCharacter, ref string bot, int botChoice)
    {
        if (botChoice == 1)
        {
            bCharacter = b;
            bot = "AverageMan";
        }
        if (botChoice == 2)
        {
            bCharacter = bIce;
            bot = "ChillBro";
        }
        if (botChoice == 3)
        {
            bCharacter = bEdgy;
            bot = "PhantomBuckaroo";
        }
        if (botChoice == 4)
        {
            bCharacter = bTokyo;
            bot = "WalmartBruceLee";
        }
        if (botChoice == 5)
        {
            bCharacter = bAce;
            bot = "JackOfAllTrades";
        }
    }
}
