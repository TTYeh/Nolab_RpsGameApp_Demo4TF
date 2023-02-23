//using static Java.Util.Jar.Attributes;
using Nolab_GAgame_practice.Functions;
namespace Nolab_GAgame_practice;

public partial class MainPage : ContentPage
{
    int yourScore = 0;
    public MainPage()
	{
		InitializeComponent();
	}

    private string GetResult(GameValue userValue)
    {
        var random = new Random(Guid.NewGuid().GetHashCode());
        // 使用者出拳
        var player1 = Game.GetInstance(userValue);
        // 電腦出拳
        var player2Value = (GameValue)random.Next(0, 3);
        var player2 = Game.GetInstance(player2Value);
        // 比拳
        GameResult result = player1.Throw(player2);
        // 顯示結果(圖片)
        this.ShowImageUser(userValue);
        this.ShowImage(player2Value);
        // 顯示結果(文字)+(更新分數)
        updateScore(result);
        if (result == GameResult.Win)
            return "You Win(你贏了)!";
        else if (result == GameResult.Lose)
            return "You Lose!(你輸了)";
        else
            return "Draw!(平手)";
    }

    private void updateScore(GameResult result)
    {
        if (result == GameResult.Win)
            this.yourScore += 100;
        else if (result == GameResult.Lose)
            this.yourScore -= 100;
        labelScore.Text = "你的得分: " + this.yourScore;
    }
    
    private void ShowImageUser(GameValue gv)
    {
        //ComputerImg.Source = ImageSource.FromResource("Nolab_RpsGameApp_MauiApp.dotnet_bot.png");
        if (gv == GameValue.Paper) userImg.Source = ImageSource.FromFile("paper.png");
        else if (gv == GameValue.Rock) userImg.Source = ImageSource.FromFile("rock.png");
        else userImg.Source = ImageSource.FromFile("scissors.png");
    }
    private void ShowImage(GameValue gv)
    {
        //ComputerImg.Source = ImageSource.FromResource("Nolab_RpsGameApp_MauiApp.dotnet_bot.png");
        if (gv == GameValue.Paper) ComputerImg.Source = ImageSource.FromFile("paper.png");
        else if (gv == GameValue.Rock) ComputerImg.Source = ImageSource.FromFile("rock.png");
        else ComputerImg.Source = ImageSource.FromFile("scissors.png");
    }

    private void Paper_clicked(object sender, EventArgs e)
    {
        gameResult.Text = GetResult(GameValue.Paper);
    }

    private void Rock_clicked(object sender, EventArgs e)
    {
        gameResult.Text = GetResult(GameValue.Rock);
    }

    private void Scissors_clicked(object sender, EventArgs e)
    {
        gameResult.Text = GetResult(GameValue.Scissors);
    }
}

