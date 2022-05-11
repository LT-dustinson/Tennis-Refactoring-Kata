namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private int _mScore1 = 0;
        private int _mScore2 = 0;

        public TennisGame1(string player1Name, string player2Name)
        {
        }

        public enum Scores
        {
            Love,
            Fifteen,
            Thirty,
            Forty,
            Deuce
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                _mScore1 += 1;
            else
                _mScore2 += 1;
        }

        public string GetScore()
        {
            var score = "";
            if (IsEqualScore())
            {
                score = CalculateTieScore();
            }
            else if (IsWinningScore())
            {
                score = SetAdvantageOrWinScore();
            }
            else
            {
                score = SetAsdf(score);
            }

            return score;
        }

        private string SetAsdf(string score)
        {
            return SetScore(_mScore1, score) + "-" + SetScore(_mScore2, score);
        }

        private string SetAdvantageOrWinScore()
        {
            var minusResult = _mScore1 - _mScore2;
            var score = minusResult switch
            {
                1 => "Advantage player1",
                -1 => "Advantage player2",
                >= 2 => "Win for player1",
                _ => "Win for player2"
            };
            return score;
        }

        private static string SetScore(int tempScore, string score)
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

        private string CalculateTieScore()
        {
            return _mScore1 switch
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
            return _mScore1 >= winningPoint || _mScore2 >= winningPoint;
        }

        private bool IsEqualScore()
        {
            return _mScore1 == _mScore2;
        }
    }
}