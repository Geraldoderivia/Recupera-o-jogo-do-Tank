using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class UIManager : MonoBehaviourPunCallbacks
{
    //Refer�ncia ao bot�o de iniciar partida
    public Button buttonIniciarPartida;

    //Refer�ncia ao bot�o de recome�ar a partida
    public Button buttonRecomecarPartida;

    //Refer�ncia ao texto da UI de status
    public  Text textStatus;

    // Start is called before the first frame update
    void Start()
    {
        //Inativa o bot�o pois o jogo acabou de come�ar
        buttonIniciarPartida.gameObject.SetActive(false);
        buttonRecomecarPartida.gameObject.SetActive(false);

        //Inicia o texto como Carregando enquanto o jogo est� carregando
        textStatus.text = "Carregando...";
    }

    //M�todo respons�vel por atualizar a interface
    public void AtualizarUI()
    {
        //Verifica se � o host da partida (geralmente o primeiro que entra ou cria a sala)
        if (PhotonNetwork.IsMasterClient)
        {
            //Mostra o bot�o de iniciar partida, pois somente o host pode fazer isso
            buttonIniciarPartida.gameObject.SetActive(true);

            //Esconde de status da partida
            textStatus.gameObject.SetActive(false);
        }
        else
        {
            //Esconde o bot�o de iniciar partida, pois somente o host pode fazer isso
            buttonIniciarPartida.gameObject.SetActive(false);

            //Mostra e define um texto do status da partida
            textStatus.gameObject.SetActive(true);
            textStatus.text = "Aguardando dono da sala iniciar a partida";
        }
    }
}
