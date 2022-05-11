namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private int _player1Points;
        private int _player2Points;
        private readonly string _player1Name;

        public TennisGame1(string player1Name, string player2Name)
        {
            _player1Name = player1Name;
        }

        private enum Scores
        {
            Love,
            Fifteen,
            Thirty,
            Forty,
            Deuce
        }

        public void WonPoint(string playerName)
        {
            if (playerName == _player1Name)
                _player1Points += 1;
            else
                _player2Points += 1;
        }

        public string GetScore()
        {
            if (IsTieScore())
                return SetTieScore();

            if (IsWinningScore())
                return SetAdvantageOrWinScore();
            
            return SetPlayersScore();
            
        }

        private string SetPlayersScore()
        {
            return SetScore(_player1Points) + "-" + SetScore(_player2Points);
        }

        private string SetAdvantageOrWinScore()
        {
            var minusResult = _player1Points - _player2Points;
            var score = minusResult switch
            {
                1 => $"Advantage {_player1Name}",
                -1 => "Advantage player2",
                >= 2 => $"Win for {_player1Name}",
                _ => "Win for player2"
            };
            return score;
        }

        private static string SetScore(int tempScore)
        {
            return GetScoreStringFromNumber(tempScore).ToString();
        }

        private static Scores GetScoreStringFromNumber(int tempScore)
        {
            return tempScore switch
            {
                0 => Scores.Love,
                1 => Scores.Fifteen,
                2 => Scores.Thirty,
                _ => Scores.Forty
            };
        }

        private string SetTieScore()
        {
            return _player1Points switch
            {
                0 => $"{Scores.Love}-All",
                1 => $"{Scores.Fifteen}-All",
                2 => $"{Scores.Thirty}-All",
                _ => Scores.Deuce.ToString()
            };
        }

        private bool IsWinningScore()
        {
            const int winningPoint = 4;
            return _player1Points >= winningPoint || _player2Points >= winningPoint;
        }

        private bool IsTieScore()
        {
            return _player1Points == _player2Points;
        }
    }
}