
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class ScoreManager : MonoBehaviourPunCallbacks
{
    // Adiciona a pontua��o ao jogador
    public void AdicionarPontuacao(Player atirador)
    {
        //Inicializa a pontua��o como zero e obtem a pontua��o do jogador
        int pontuacaoAtual = 0;
        if (atirador.CustomProperties.ContainsKey("Pontuacao"))
        {
            pontuacaoAtual = (int)atirador.CustomProperties["Pontuacao"];
        }

        //Adiciona a pontua��o em 1
        pontuacaoAtual += 1;

        //Atualiza a pontua��o no PhotonPun e notifica todos jogadores, fazendo isso, o Photon Pun executar� o m�todo OnPlayerPropertiesUpdate da classe PontuacaoUIController
        Hashtable propriedadePontuacao = new Hashtable();
        propriedadePontuacao["Pontuacao"] = pontuacaoAtual;
        atirador.SetCustomProperties(propriedadePontuacao);
    }
    //M�todo que reseta a pontua��o do player
    public void ResetarPontuacao(Player player)
    {
        //Atualiza a pontua��o no PhotonPun e notifica todos jogadores, fazendo isso, o Photon Pun executar� o m�todo OnPlayerPropertiesUpdate da classe PontuacaoUIController
        Hashtable propriedadePontuacao = new Hashtable();
        propriedadePontuacao["Pontuacao"] = 0;
        player.SetCustomProperties(propriedadePontuacao);
    }
}
