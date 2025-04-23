using Godot;
using System;

public partial class MonitorAlternativa : Node
{
    private Button alternativaA;
    private Button alternativaB;
    private Button alternativaC;
    private Button alternativaD;

    private Button descricaoA;
    private Button descricaoB;
    private Button descricaoC;
    private Button descricaoD;

    private GameManager gm;
    private Player player;

    public override void _Ready() 
    {
        base._Ready();
        alternativaA = GetNode<Button>("Alternativas/A");
        alternativaB = GetNode<Button>("Alternativas/B");
        alternativaC = GetNode<Button>("Alternativas/C");
        alternativaD = GetNode<Button>("Alternativas/D");
        
        descricaoA = GetNode<Button>("Respostas/A");
        descricaoB = GetNode<Button>("Respostas/B");
        descricaoC = GetNode<Button>("Respostas/C");
        descricaoD = GetNode<Button>("Respostas/D");

        gm = GetNode<GameManager>("/root/GameManager");


        showAlternatives(gm.actualQuestion);

        alternativaA.Pressed += () => CheckCorrectAnswer(gm.actualQuestion.alternativaA);
        descricaoA.Pressed += () => CheckCorrectAnswer(gm.actualQuestion.alternativaA);

        alternativaB.Pressed += () => CheckCorrectAnswer(gm.actualQuestion.alternativaB);
        descricaoB.Pressed += () =>CheckCorrectAnswer(gm.actualQuestion.alternativaB);

        alternativaC.Pressed += () =>CheckCorrectAnswer(gm.actualQuestion.alternativaC);
        descricaoC.Pressed += () =>CheckCorrectAnswer(gm.actualQuestion.alternativaC);

        alternativaD.Pressed += () => CheckCorrectAnswer(gm.actualQuestion.alternativaD);
        descricaoD.Pressed += () =>CheckCorrectAnswer(gm.actualQuestion.alternativaD);
    }

    private void showAlternatives(QuestionData perguntaAtual)
    {   
        descricaoA.Text = perguntaAtual.alternativaA;
        descricaoB.Text = perguntaAtual.alternativaB;
        descricaoC.Text = perguntaAtual.alternativaC;
        descricaoD.Text = perguntaAtual.alternativaD;
    }

    private void CheckCorrectAnswer(string alternativaSelecionada)
    {
        if (gm.canAnswer)
        {
            if(alternativaSelecionada == gm.actualQuestion.alternativaCorreta)
            {
                player.correctAnswers += 1;
                //Realiza Calculo do ponto em relação ao tempo;
                player.canAnswer = false;
                GD.Print("Resposta Correta");
            }
            else
            {
                GD.Print("Resposta Incorreta");
                player.canAnswer = false;
                gm.EraseActualQuestion();
            }
        }
        else
        {
            return;
        }
    }
}
