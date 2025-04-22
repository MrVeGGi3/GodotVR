using Godot;
using System;
using System.Collections.Generic;

public partial class QuestionSelector : Node
{
    private CSVOpener loadedQuestions;
    private GameManager gm;



    public override void _Ready() 
    {
        base._Ready();
        loadedQuestions = GetNode<CSVOpener>();
        gm = GetNode<GameManager>();
        ChooseQuestion(gm.questionType);
    }

    public void ChooseQuestion(string choosedCategory)
    {
        List <QuestionData> perguntas = loadedQuestions.perguntas;
        foreach(QuestionData pergunta in perguntas)
        {
            if(pergunta.categoria == choosedCategory && 
            !pergunta.questãoRespondida &&
            pergunta.dificuldade == gm.actualDifficulty)
            {
                pergunta.questãoRespondida = true;
                gm.actualQuestion = pergunta;
                break;
            }
        }
    }
}
