namespace Events2
{
    internal class Program
    {
        //public event Action OnPlayerDamaged;
        static void Main(string[] args)
        {
            Player player = new Player();
            player.dmg(45); //dont have listeners

            PlayerHealtBar playerHealtBar = new PlayerHealtBar(player);
            PlayermanaBar playermanaBar = new PlayermanaBar(player);
            player.dmg(45);

        }
        private class Player()
        {
            //public event Action<int> OnplayerDamaged;
            //public Action OnplayerDamaged; // it is still works but the listeneres now can invoke the function.

            public class OnPlayerDmgEvenetArgs: EventArgs {
                public int previusHealth { get; set; }
            }

            public event EventHandler<OnPlayerDmgEvenetArgs> OnplayerDamaged;

            public void dmg(int i)
            {
                if (OnplayerDamaged != null) //nullcheck
                {
                    OnplayerDamaged(this, new OnPlayerDmgEvenetArgs
                    {
                        previusHealth = 50
                    }
                    );
                }
                
                    OnplayerDamaged?.Invoke(this, new OnPlayerDmgEvenetArgs //same but more compact
                    {
                        previusHealth = 50
                    }
                    );
                
            }
        }
        private class PlayerHealtBar //if i delet this class the Onplayerdamaged action is still available.
        {
            public PlayerHealtBar(Player player)
            {
                player.OnplayerDamaged += Player_OnplayerDamaged1; ; //subscribe
                //player.OnplayerDamaged -= Player_OnplayerDamaged; //unsubscribe
            }

            private void Player_OnplayerDamaged1(object? sender, Player.OnPlayerDmgEvenetArgs e)
            {
                Console.WriteLine("On_playerdmg event");
            }

            private void Player_OnplayerDamaged(int i)
            {
                
            }
        }
        private class PlayermanaBar //if i delet this class the Onplayerdamaged action is still available.
        {
            public PlayermanaBar(Player player)
            {
                player.OnplayerDamaged += Player_OnplayerDamaged1
                    ; 
            }

            private void Player_OnplayerDamaged1(object? sender, Player.OnPlayerDmgEvenetArgs e)
            {
                e.previusHealth = 50; //accesable
                Console.WriteLine("manabar is changed");
            }

            private void Player_OnplayerDamaged(int i)
            {
                
            }
        }
    }
}
