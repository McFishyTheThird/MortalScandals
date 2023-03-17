using Raylib_cs;

public class Player
{
    public Rectangle playerPlace;
    public Texture2D playerCharacter;
    public float speed;
    public int canCrouch;
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
    public int pYMax;
    public float jumpPowerMax;
    public float jumpPowerMin;
    public int knockbackImmunity;

    public void MoveLeft(Player target)
    {
        playerPlace.x -= speed;
    }
    public void MoveRight(Player target)
    {
        playerPlace.x += speed;
    }
    public void DrawHp(string pCName, Rectangle hpBG)
    {
        Raylib.DrawRectangleRec(hpBG, Color.WHITE);
        Raylib.DrawText($"{pCName}: {hp} hp", 250, 110, 30, Color.BLACK);
    }
    public void LoadCharacter(Player pCharacter, Bot bCharacter, string player, int isJumping, int isCrouching, ref int isPunching, int isLookingRight, int isLookingLeft, ref int loadCharacter, ref int punchHit, Random generator)
    {
        if (isLookingRight == 1 && loadCharacter == 1)
        {
            if (isPunching == 0 && isJumping == 0 && isCrouching == 0 && Raylib.IsKeyDown(KeyboardKey.KEY_W) == false)
            {
                pCharacter.playerCharacter = Raylib.LoadTexture($"{player}/CharacterRight.png");
                pCharacter.playerPlace.width = pCharacter.playerCharacter.width;
                pCharacter.playerPlace.height = pCharacter.playerCharacter.height;
            }
            else if (isJumping == 1 && isPunching == 0)
            {
                pCharacter.playerCharacter = Raylib.LoadTexture($"{player}/CharacterJumpingRight.png");
                pCharacter.playerPlace.width = pCharacter.playerCharacter.width;
                pCharacter.playerPlace.height = pCharacter.playerCharacter.height;
            }
            else if (isJumping == 1 && isPunching == 1)
            {
                pCharacter.playerCharacter = Raylib.LoadTexture($"{player}/CharacterJumpPunchRight.png");
                pCharacter.playerPlace.width = pCharacter.playerCharacter.width;
                pCharacter.playerPlace.height = pCharacter.playerCharacter.height;
                if (Raylib.CheckCollisionRecs(pCharacter.playerPlace, bCharacter.botPlace))
                {
                    bCharacter.hp -= generator.Next(pCharacter.punchDamageMin, pCharacter.punchDamageMax);
                    punchHit = 1;
                }
            }
            else if (isPunching == 1)
            {
                pCharacter.playerCharacter = Raylib.LoadTexture($"{player}/CharacterPunchingRight.png");
                pCharacter.playerPlace.width = pCharacter.playerCharacter.width;
                pCharacter.playerPlace.height = pCharacter.playerCharacter.height;
                //Damage for punching
                if (Raylib.CheckCollisionRecs(pCharacter.playerPlace, bCharacter.botPlace))
                {
                    bCharacter.hp -= generator.Next(pCharacter.punchDamageMin, pCharacter.punchDamageMax);
                    punchHit = 1;
                }
            }
            loadCharacter = 0;
        }
        if (isLookingLeft == 1 && loadCharacter == 1)
        {
            if (isPunching == 0 && isJumping == 0 && isCrouching == 0 && Raylib.IsKeyDown(KeyboardKey.KEY_W) == false)
            {
                pCharacter.playerCharacter = Raylib.LoadTexture($"{player}/CharacterLeft.png");
                pCharacter.playerPlace.width = pCharacter.playerCharacter.width;
                pCharacter.playerPlace.height = pCharacter.playerCharacter.height;
            }
            else if (isJumping == 1 && isPunching == 0)
            {
                pCharacter.playerCharacter = Raylib.LoadTexture($"{player}/CharacterJumpingLeft.png");
                pCharacter.playerPlace.width = pCharacter.playerCharacter.width;
                pCharacter.playerPlace.height = pCharacter.playerCharacter.height;
            }
            else if (isJumping == 1 && isPunching == 1)
            {
                pCharacter.playerCharacter = Raylib.LoadTexture($"{player}/CharacterJumpPunchLeft.png");
                pCharacter.playerPlace.width = pCharacter.playerCharacter.width;
                pCharacter.playerPlace.height = pCharacter.playerCharacter.height;
                pCharacter.playerPlace.x -= 50;
                if (Raylib.CheckCollisionRecs(pCharacter.playerPlace, bCharacter.botPlace))
                {
                    bCharacter.hp -= generator.Next(pCharacter.punchDamageMin, pCharacter.punchDamageMax);;
                    punchHit = 1;
                }
            }
            else if (isPunching == 1)
            {
                pCharacter.playerCharacter = Raylib.LoadTexture($"{player}/CharacterPunchingLeft.png");
                pCharacter.playerPlace.width = pCharacter.playerCharacter.width;
                pCharacter.playerPlace.height = pCharacter.playerCharacter.height;
                //Damage for punching
                pCharacter.playerPlace.x -= 100;
                if (Raylib.CheckCollisionRecs(pCharacter.playerPlace, bCharacter.botPlace))
                {
                    bCharacter.hp -= generator.Next(pCharacter.punchDamageMin, pCharacter.punchDamageMax);;
                    punchHit = 1;
                }
            }
            loadCharacter = 0;
        }
    }
    public void Reset(Player pSecret, Player pCharacter, out int isJumping, out int isCrouching, out int isPunching, out int isLookingRight, out int isLookingLeft, out int punchHit, string player)
    {
        isJumping = 0;
        isCrouching = 0;
        isPunching = 0;
        isLookingRight = 1;
        isLookingLeft = 0;
        pCharacter.playerCharacter = Raylib.LoadTexture($"{player}/CharacterRight.png");
        punchHit = 0;
        if (pCharacter == pSecret)
        {
            pCharacter.playerPlace = new Rectangle(0, 398, 100, 200);
        }
        else
        {
            pCharacter.playerPlace = new Rectangle(0, 600, 100, 200);
        }
    }
    public int KnockBack(Player pCharacter, Bot bCharacter, Rectangle ground, int isLookingRight, int punchHit)
    {
        if (punchHit == 1 && isLookingRight == 1)
        {
            bCharacter.botPlace.x += pCharacter.knockback;
            pCharacter.knockback -= 0.5f;
            if (pCharacter.knockback <= 0)
            {
                punchHit = 0;
                pCharacter.knockback = pCharacter.knockbackMax;
            }
            if (bCharacter.botPlace.x >= ground.width - 180)
            {
                bCharacter.botPlace.x = ground.width - 180;
            }
        }

        return punchHit;
    }
    public void CharacterSelection(Player p, Player pAce, Player pDuck, Player pIce, Player pEdgy, Player pTokyo, int selectedCharacter, string currentScene)
    {
        //character selection
        Raylib.DrawText(currentScene, 10, 10, 30, Color.BLACK);
        if (selectedCharacter != 1)
        {
            Raylib.DrawTexture(p.playerCharacter, 500, 300, Color.WHITE);
        }
        else
        {
            Raylib.DrawRectangle(500, 300, p.playerCharacter.width, p.playerCharacter.height, Color.GOLD);
            Raylib.DrawTexture(p.playerCharacter, 500, 300, Color.WHITE);
        }
        if (selectedCharacter != 2)
        {
            Raylib.DrawTexture(pAce.playerCharacter, 910, 288, Color.WHITE);
        }
        else
        {
            Raylib.DrawRectangle(910, 288, pAce.playerCharacter.width, pAce.playerCharacter.height, Color.GOLD);
            Raylib.DrawTexture(pAce.playerCharacter, 910, 288, Color.WHITE);
        }
        if (selectedCharacter != 3)
        {
            Raylib.DrawTexture(pIce.playerCharacter, 1420, 300, Color.WHITE);
        }
        else
        {
            Raylib.DrawRectangle(1420, 300, pIce.playerCharacter.width, pIce.playerCharacter.height, Color.GOLD);
            Raylib.DrawTexture(pIce.playerCharacter, 1420, 300, Color.WHITE);
        }
        if (selectedCharacter != 4)
        {
            Raylib.DrawTexture(pEdgy.playerCharacter, 500, 600, Color.WHITE);
        }
        else
        {
            Raylib.DrawRectangle(500, 600, pEdgy.playerCharacter.width, pEdgy.playerCharacter.height, Color.GOLD);
            Raylib.DrawTexture(pEdgy.playerCharacter, 500, 600, Color.WHITE);
        }
        if (selectedCharacter != 5)
        {
            Raylib.DrawTexture(pDuck.playerCharacter, 910, 600, Color.WHITE);
        }
        else
        {
            Raylib.DrawRectangle(910, 600, pDuck.playerCharacter.width, pDuck.playerCharacter.height, Color.GOLD);
            Raylib.DrawTexture(pDuck.playerCharacter, 910, 600, Color.WHITE);
        }
        if (selectedCharacter != 6)
        {
            Raylib.DrawTexture(pTokyo.playerCharacter, 1420, 600, Color.WHITE);
        }
        else
        {
            Raylib.DrawRectangle(1420, 600, pTokyo.playerCharacter.width, pTokyo.playerCharacter.height, Color.GOLD);
            Raylib.DrawTexture(pTokyo.playerCharacter, 1420, 600, Color.WHITE);
        }
        Raylib.DrawText("Average Man", 490, 550, 20, Color.BLACK);
        Raylib.DrawText("Jack Of All Trades", 860, 550, 20, Color.BLACK);
        Raylib.DrawText("Chill Bro", 1420, 550, 20, Color.BLACK);
        Raylib.DrawText("Phantom Buckaroo", 460, 850, 20, Color.BLACK);
        Raylib.DrawText("Walmart Bruce Lee", 1370, 850, 20, Color.BLACK);
    }
}
