using Godot;
using System;
using System.Collections.Generic;

public partial class GameManager : Node
{   
    public string questionType;
    public int questionNumber = -1;
    public string actualDifficulty = "Easy";

    public bool timeStart = false;

    public QuestionData actualQuestion;
    public List <String> categories = new List<String>();

    public override void _Ready()
    {
        base._Ready();
        categories.AddRange(new [] {"Surprise", "History", "Science", "Sports", 
        "Entertainment", "Languages", "Geography", "Arts"});
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
        if (questionNumber >= 0)
        {
            AssignQuestionType(questionNumber);
        }
    }

    private void AssignQuestionType(int numberType)
    {
        questionType = categories[numberType];
        questionNumber = -1;
    }

    public void EraseActualQuestion()
    {
        actualQuestion = null;
    }
}
