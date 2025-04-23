using Godot;
using System;
using System.Collections.Generic;

public partial class CSVOpener : Node
{
    public List <QuestionData> perguntas = new List<QuestionData>();


    public override void _Ready() 
    {
        base._Ready();
        LoadCSV("res://Data/XRTrivia - Perguntas em Português - Perguntas (1).csv");
    }


    public void LoadCSV(string filePath)
    {
        var file = FileAccess.Open(filePath, FileAccess.ModeFlags.Read);

        if(file == null)
        {
            GD.Print("Erro ao abrir o arquivo CSV");
            return;
        }
        
        bool isFirstLine = true;

        while(!file.EofReached())
        {
            var line = file.GetLine();
            if(isFirstLine)
            {
                isFirstLine = false;
                continue;
            }

            var fields = line.Split(',');

            if (fields.Length >= 9)
            {
                var pergunta = new QuestionData
                {
                    categoria = fields[0],
                    pergunta = fields[1],
                    alternativaA = fields[2],
                    alternativaB = fields[3],
                    alternativaC = fields[4],
                    alternativaD = fields[5],
                    alternativaCorreta = fields[6],
                    dificuldade = fields[7],
                    questãoRespondida = false              
                };

                perguntas.Add(pergunta);

            }
        }

        file.Close();

    }
}

public class QuestionData
{
    public string categoria;
    public string pergunta;
    public string alternativaA;
    public string alternativaB;
    public string alternativaC;
    public string alternativaD;
    public string alternativaCorreta;
    public string dificuldade;
    public bool questãoRespondida;
}