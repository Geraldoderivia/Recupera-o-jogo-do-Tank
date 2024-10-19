using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class UIManager : MonoBehaviourPunCallbacks
{
    //Referência ao botão de iniciar partida
    public Button buttonIniciarPartida;

    //Referência ao botão de recomeçar a partida
    public Button buttonRecomecarPartida;

    //Referência ao texto da UI de status
    public  Text textStatus;

    // Start is called before the first frame update
    void Start()
    {
        //Inativa o botão pois o jogo acabou de começar
        buttonIniciarPartida.gameObject.SetActive(false);
        buttonRecomecarPartida.gameObject.SetActive(false);

        //Inicia o texto como Carregando enquanto o jogo está carregando
        textStatus.text = "Carregando...";
    }

    //Método responsável por atualizar a interface
    public void AtualizarUI()
    {
        //Verifica se é o host da partida (geralmente o primeiro que entra ou cria a sala)
        if (PhotonNetwork.IsMasterClient)
        {
            //Mostra o botão de iniciar partida, pois somente o host pode fazer isso
            buttonIniciarPartida.gameObject.SetActive(true);

            //Esconde de status da partida
            textStatus.gameObject.SetActive(false);
        }
        else
        {
            //Esconde o botão de iniciar partida, pois somente o host pode fazer isso
            buttonIniciarPartida.gameObject.SetActive(false);

            //Mostra e define um texto do status da partida
            textStatus.gameObject.SetActive(true);
            textStatus.text = "Aguardando dono da sala iniciar a partida";
        }
    }
}
