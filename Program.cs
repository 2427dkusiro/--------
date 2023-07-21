using API;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapPost("/user", (string name) =>
{
    var context = new MyDBContext();
    using var tran = context.Database.BeginTransaction();
    var user = context.UserInfo.Add(new()
    {
        Name = name,
    }).Entity;
    context.SaveChanges();
    context.UserAmount.Add(new()
    {
        Amount = 100,
        UserInfo = user
    });
    context.SaveChanges();
    tran.Commit();
    return user.Id;
});

app.MapPost("/janken/{userChoice}", IResult (string userChoice, long userId, long amount) =>
{
    var choices = new[] { "グー", "チョキ", "パー" };
    if (!choices.Contains(userChoice))
    {
        return Results.BadRequest("無効な手です");
    }

    var context = new MyDBContext();
    var UserAmount = context.UserAmount.First(x => x.UserInfo!.Id == userId);
    if (UserAmount.Amount < amount)
    {
        return Results.BadRequest("残高が足りません");
    }

    var userIndex = Array.IndexOf(choices, userChoice);
    var cpuIndex = new Random().Next(choices.Length);

    string msg;
    if (userIndex == cpuIndex)
    {
        msg = "あいこ！";
    }
    else if ((userIndex + 1) % choices.Length == cpuIndex)
    {
        msg = "あなたの勝ち！";
        UserAmount.Amount += amount;
        context.SaveChanges();
    }
    else
    {
        msg = "あなたの負け！";
        UserAmount.Amount -= amount;
        context.SaveChanges();
    }
    return Results.Ok(new { User = userChoice, CPU = choices[cpuIndex], Message = msg, UserAmount.Amount });
});

app.Run();

