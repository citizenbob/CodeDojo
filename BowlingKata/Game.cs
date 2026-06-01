namespace Bowling;

public class Game
{
    private int[] _rolls = new int[21];
    private int _currentRoll = 0;

    public void Roll(int pins)
    {
        _rolls[_currentRoll++] = pins;
    }
    public int Score()
    {
        var sum = 0;
        var i = 0;
        for (var frame = 0; frame < 10; frame++)
        {
            // if the first in the frame scores ten pins
            if (_rolls[i] == 10)
            {
                // add the pin total from the next two rolls to the ten pins as a bonus
                sum += 10 + _rolls[i + 1] + _rolls[i + 2];
                // close the frame
                i += 1;
            }
            // if the first and second rolls in the frame score ten pins
            else if (_rolls[i] + _rolls[i + 1] == 10)
            {
                // add the pin total from the next roll to the ten pins as a bonus
                sum += 10 + _rolls[i + 2];
                // close the frame
                i += 2;
            }
            else
            {
                // sum the pin total from both frames
                sum += _rolls[i] + _rolls[i + 1];
                // close the frame
                i += 2;
            }
        }
        return sum;
    }
}