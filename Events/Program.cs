namespace Events
{
    internal class Program
    {
        //public event Action OnPlayerDamaged;
        static void Main(string[] args)
        {
            Player player = new Player();
            player.dmg(); //dont have listeners

            PlayerHealtBar playerHealtBar = new PlayerHealtBar(player);
            PlayermanaBar playermanaBar = new PlayermanaBar(player);
            player.dmg();

        }
        private class Player()
        {
            public event Action OnplayerDamaged;
            //public Action OnplayerDamaged; // it is still works but the listeneres now can invoke the function.
            public void dmg()
            {
                if (OnplayerDamaged != null) {
                    OnplayerDamaged(); //dosent know how is liseneted. it is just happend.
                }
            }
        }
        private class PlayerHealtBar //if i delet this class the Onplayerdamaged action is still available.
        {
            public PlayerHealtBar(Player player)
            {
                player.OnplayerDamaged += Player_OnplayerDamaged; //subscribe
                //player.OnplayerDamaged -= Player_OnplayerDamaged; //unsubscribe
            }

            private void Player_OnplayerDamaged()
            {
                Console.WriteLine("On_playerdmg event");
            }
        }
        private class PlayermanaBar //if i delet this class the Onplayerdamaged action is still available.
        {
            public PlayermanaBar(Player player)
            {
                player.OnplayerDamaged += Player_OnplayerDamaged;
            }

            private void Player_OnplayerDamaged()
            {
                Console.WriteLine("manabar is changed");
            }
        }
    }
}
