using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nolab_GAgame_practice.Functions
{
    public abstract class Game
    {
        public GameValue Value { get; }

        public static Game GetInstance(GameValue value)
        {
            if (value == GameValue.Scissors)
                return new Scissors();
            else if (value == GameValue.Rock)
                return new Rock();
            else
                return new Paper();
        }

        public Game(GameValue value)
        {
            Value = value;
        }
        public abstract GameResult Throw(Game other);

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
    public class Rock : Game
    {
        public Rock() : base(GameValue.Rock) { }

        public override GameResult Throw(Game other)
        {
            if (other.Value == GameValue.Scissors)
                return GameResult.Win;
            else if (other.Value == GameValue.Rock)
                return GameResult.Draw;
            else
                return GameResult.Lose;
        }
    }
    public class Paper : Game
    {
        public Paper() : base(GameValue.Paper) { }

        public override GameResult Throw(Game other)
        {
            switch (other.Value)
            {
                case GameValue.Scissors:
                    return GameResult.Lose;
                case GameValue.Rock:
                    return GameResult.Win;
                case GameValue.Paper:
                    return GameResult.Draw;
                default:
                    throw new Exception("無法指出的錯誤");
            }

        }
    }
    public class Scissors : Game
    {
        public Scissors() : base(GameValue.Scissors) { }

        public override GameResult Throw(Game other)
        {
            Dictionary<GameValue, GameResult> maps = new Dictionary<GameValue, GameResult> {
                {GameValue.Scissors, GameResult.Draw },
                {GameValue.Rock, GameResult.Lose },
                {GameValue.Paper, GameResult.Win }
            };
            return maps[other.Value];

        }
    }

    public enum GameResult
    {
        Win, Lose, Draw
    }
    public enum GameValue
    {
        Rock = 0, Paper = 1, Scissors = 2
    }
}
