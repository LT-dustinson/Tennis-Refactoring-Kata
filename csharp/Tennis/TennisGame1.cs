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
                score = SetASDF(score);
            }

            return score;
        }

        private string SetASDF(string score)
        {
            int tempScore;
            for (var i = 1; i < 3; i++)
            {
                if (i == 1) tempScore = _mScore1;
                else
                {
                    score += "-";
                    tempScore = _mScore2;
                }

                score = SetScore(tempScore, score);
            }

            return score;
        }

        private string SetAdvantageOrWinScore()
        {
            string score;
            var minusResult = _mScore1 - _mScore2;
            if (minusResult == 1) score = "Advantage player1";
            else if (minusResult == -1) score = "Advantage player2";
            else if (minusResult >= 2) score = "Win for player1";
            else score = "Win for player2";
            return score;
        }

        private static string SetScore(int tempScore, string score)
        {
            switch (tempScore)
            {
                case 0:
                    score += Scores.Love;
                    break;
                case 1:
                    score += Scores.Fifteen;
                    break;
                case 2:
                    score += Scores.Thirty;
                    break;
                case 3:
                    score += Scores.Forty;
                    break;
            }

            return score;
        }

        private bool IsWinningScore()
        {
            return _mScore1 >= 4 || _mScore2 >= 4;
        }

        private string CalculateTieScore()
        {
            string score;
            switch (_mScore1)
            {
                case 0:
                    score = $"{Scores.Love}-All";
                    break;
                case 1:
                    score = $"{Scores.Fifteen}-All";
                    break;
                case 2:
                    score = $"{Scores.Thirty}-All";
                    break;
                default:
                    score = Scores.Deuce.ToString();
                    break;
            }

            return score;
        }

        private bool IsEqualScore()
        {
            return _mScore1 == _mScore2;
        }
    }
}