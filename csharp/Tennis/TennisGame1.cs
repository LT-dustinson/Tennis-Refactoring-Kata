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
            for (var i = 1; i < 3; i++)
            {
                int tempScore;
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
            score = minusResult switch
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
            score += GetScoreStringFromNumber(tempScore);

            return score;
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

        private bool IsWinningScore()
        {
            return _mScore1 >= 4 || _mScore2 >= 4;
        }

        private bool IsEqualScore()
        {
            return _mScore1 == _mScore2;
        }
    }
}