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
        alternativaA = GetNode<Button>();
        alternativaB = GetNode<Button>();
        alternativaC = GetNode<Button>();
        alternativaD = GetNode<Button>();
        
        descricaoA = GetNode<Button>();
        descricaoB = GetNode<Button>();
        descricaoC = GetNode<Button>();
        descricaoD = GetNode<Button>();

        gm = GetNode<GameManager>();
        player = GetNode<Player>();


        showAlternatives(gm.actualQuestion)

        alternativaA.Pressed += () => CheckCorrectAnswer(gm.actualQuestion.alternativaA)
        descricaoA.Pressed += () => CheckCorrectAnswer(gm.actualQuestion.alternativaA)

        alternativaB.Pressed += () => CheckCorrectAnswer(gm.actualQuestion.alternativaB)
        descricaoB.Pressed += () =>CheckCorrectAnswer(gm.actualQuestion.alternativaB)

        alternativaC.Pressed += () =>CheckCorrectAnswer(gm.actualQuestion.alternativaC)
        descricaoC.Pressed += () =>CheckCorrectAnswer(gm.actualQuestion.alternativaC)

        alternativaD.Pressed += () => CheckCorrectAnswer(gm.actualQuestion.alternativaD)
        descricaoD.Pressed += () =>CheckCorrectAnswer(gm.actualQuestion.alternativaD)
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
        if (player.canAnswer)
        {
            if(alternativaSelecionada == gm.actualQuestion.alternativaCorreta)
            {
                player.correctAnswers += 1;
                //Realiza Calculo do ponto em relação ao tempo;
                player.canAnswer = false;
                GD.Print("Respota Correta");
            }
            else:
                GD.Print("Resposta Incorreta");
                player.canAnswer = false;
                gm.EraseActualQuestion();
        }
        else:
            return;
    }
}
