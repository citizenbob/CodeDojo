namespace BowlingTDD;

public class Game
{
        private int[] _game = new int[21];
        private int _currentRoll = 0;

        public void Bowl(int pins)
        {
                _game[_currentRoll] = pins;
                _currentRoll++;
        }

        public int Score()
        {
                int score = 0;
                int rollIndex = 0;
                for (int frame = 0; frame < 10; frame++)
                {
                        if (isStrike(rollIndex))
                        {
                                score = ScoreStrike(score, ref rollIndex);
                        }
                        else if (isSpare(rollIndex))
                        {
                                score = ScoreSpare(score, ref rollIndex);
                        }
                        else
                        {
                                score = ScoreFrame(score, ref rollIndex);
                        }
                }

                return score;
        }

        private int ScoreStrike(int score, ref int rollIndex)
        {
                score += 10 + _game[rollIndex + 1] + _game[rollIndex + 2];
                rollIndex += 1;
                return score;
        }
        private int ScoreSpare(int score, ref int rollIndex)
        {
                score += 10 + _game[rollIndex + 2];
                rollIndex += 2;
                return score;
        }

        private int ScoreFrame(int score, ref int rollIndex)
        {
                score += _game[rollIndex] + _game[rollIndex + 1];
                rollIndex += 2;
                return score;
        }

        private bool isSpare(int rollIndex)
        {
                return _game[rollIndex] + _game[rollIndex + 1] == 10;
        }
        private bool isStrike(int rollIndex)
        {
                return _game[rollIndex] == 10;
        }
}