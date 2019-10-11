using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiIdiomaManager : MonoBehaviour
{
    public static MultiIdiomaManager instance;
    public Dictionary<string, string> texts;

    List<string> languages = new List<string>();
    public string languageAtual = "pt-br";
    int indexLanguageAtual = 0;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        texts = new Dictionary<string, string>();

        languages.Add("pt-br");
        languages.Add("en-us");
        languages.Add("fr-fr");

        CarregarLanguage(languageAtual);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeLanguage()
    {
        indexLanguageAtual++;

        if(indexLanguageAtual == languages.Count)
        {
            indexLanguageAtual = 0;
        }

        languageAtual = languages[indexLanguageAtual];

        CarregarLanguage(languageAtual);
    }

    void CarregarLanguage(string language)
    {
        texts = new Dictionary<string, string>();

        switch (language)
        {
            case "pt-br":

                texts.Add(language + "NEXT", "Próximo");
                texts.Add(language + "VICTORY", "VITÓRIA");
                texts.Add(language + "LOSE", "DERROTA");
                texts.Add(language + "FINISH", "TERMINAR");
                texts.Add(language + "LV_UP", "AVANÇO DE LVL");
                texts.Add(language + "Level", "Nível");
                
                //################# LOBBY #######################################################################################
                texts.Add(language + "MAINCAMERA_NAMEGAME", "ESCRAVO DE VAMPIRO");

                texts.Add(language + "MENU_NEW", "NOVO");
                texts.Add(language + "MENU_LOAD", "CARREGAR");
                texts.Add(language + "MENU_CREDITS", "CREDITOS");
                texts.Add(language + "MENU_EXIT", "SAIR");

                texts.Add(language + "MENUNEW_CHARACTERNAME", "Nome do Jogador");
                texts.Add(language + "MENUNEW_CREATE", "CRIAR");
                texts.Add(language + "MENUNEW_BACK", "VOLTAR");

                texts.Add(language + "MENULOAD_LOGIN", "LOGAR >>");
                texts.Add(language + "MENULOAD_BACK", "VOLTAR");

                texts.Add(language + "MENUCREDITS_DEVELOPER", "Desenvolvedor: Thiago Melo\nContato: thiagomelo@edu.unifor.br");
                texts.Add(language + "MENUCREDITS_BACK", "VOLTAR");

                texts.Add(language + "START_NAMEGAME", "VAMPIRE SLAVE TACTICS");
                texts.Add(language + "START_DROPHUMANS", "HUMANOS DROPÁVEIS");
                texts.Add(language + "START_CAMPAIN", "CAMPANHA");
                texts.Add(language + "START_MENU", "MENU");
                texts.Add(language + "START_CITY", "CIDADE");
                texts.Add(language + "START_ASYLUM", "ASILO"); 

                texts.Add(language + "MENUHUMANS_LISTHUMANS", "LISTA DE HUMANOS");
                texts.Add(language + "MENUHUMANS_NAME", "Nome");
                texts.Add(language + "MENUHUMANS_JOB", "Classe");
                texts.Add(language + "MENUHUMANS_ENABLED", "Habilitado");
                texts.Add(language + "MENUHUMANS_DETAILS", "Detalhes");
                texts.Add(language + "MENUHUMANS_BACK", "VOLTAR");

                texts.Add(language + "MENU_C_BACK", "VOLTAR");

                //################# STATES #######################################################################################
                texts.Add(language + "CAMPAIN_Choose Action", "Selecionar Ação");
                texts.Add(language + "CAMPAIN_Confirm Skill", "Confirmar Skill");
                texts.Add(language + "CAMPAIN_IA Player", "Turno do Inimigo");
                texts.Add(language + "CAMPAIN_Loading", "Carregando");
                texts.Add(language + "CAMPAIN_Move Selection", "Seleção de Movimento");
                texts.Add(language + "CAMPAIN_Roam", "Navegar no mapa");
                texts.Add(language + "CAMPAIN_Skill Selection", "Selecionar Skill");
                texts.Add(language + "CAMPAIN_Skill Target", "Escolher Alvo");
                texts.Add(language + "CAMPAIN_NO_UNIT", "No unit would be affected");

                //################# UI ACTIONS ###################################################################################
                texts.Add(language + "MOVE", "Mover");
                texts.Add(language + "WAIT", "Esperar");
                texts.Add(language + "ROAM", "Navegar");
                texts.Add(language + "LEAVE", "Sair");

                //################# UI DIALOGS ###################################################################################
                texts.Add(language + "DIALOG_P1_1", pt_br_textP1_1);
                texts.Add(language + "DIALOG_P1_2", pt_br_textP1_2);
                texts.Add(language + "DIALOG_P1_NEXT", "Próximo");
                texts.Add(language + "DIALOG_P1_PREV", "Anterior");

                texts.Add(language + "DIALOG_P2_1", pt_br_textP2_1);
                texts.Add(language + "DIALOG_P2_NEXT", "Próximo");

                texts.Add(language + "DIALOG_P3_1", pt_br_textP3_1);
                texts.Add(language + "DIALOG_P3_NEXT", "Próximo");

                texts.Add(language + "DIALOG_P4_1", pt_br_textP4_1);
                texts.Add(language + "DIALOG_P4_NEXT", "Próximo");

                texts.Add(language + "DIALOG_P5_1", pt_br_textP5_1);

                texts.Add(language + "MENUGAMEOVER_TEXT", pt_br_textGameOver);
                texts.Add(language + "MENUGAMEOVER_MAINMENU", "MENU PRINCIPAL");

                //################# JOBS SKILLS ###################################################################################
                texts.Add(language + "JOB_Bless", "Abençoar");
                texts.Add(language + "JOB_Esuna", "Purificar");
                texts.Add(language + "JOB_FireBall", "Bola de Fogo");
                texts.Add(language + "JOB_FireBreath", "Sopro de Fogo");
                texts.Add(language + "JOB_FirePillar", "Pilar de Fogo");
                texts.Add(language + "JOB_FirstAid", "Primeiros Socorros");
                texts.Add(language + "JOB_Lunge", "Estocada");
                texts.Add(language + "JOB_NormalAttack", "Ataque Normal");
                texts.Add(language + "JOB_PoisonDart", "Dardo envenenado");                
                texts.Add(language + "JOB_Rend", "Envenenar");
                texts.Add(language + "JOB_Restoration", "Restauração");
                texts.Add(language + "JOB_Change Job", "Mudar de Classe");

                break;

            case "en-us":

                texts.Add(language + "NEXT", "Next");
                texts.Add(language + "VICTORY", "VICTORY");
                texts.Add(language + "LOSE", "LOSE");
                texts.Add(language + "FINISH", "FINISH");
                texts.Add(language + "LV_UP", "LVL UP");
                texts.Add(language + "Level", "Level");

                //################# LOBBY #######################################################################################
                texts.Add(language + "MAINCAMERA_NAMEGAME", "VAMPIRE SLAVE");

                texts.Add(language + "MENU_NEW", "NEW");
                texts.Add(language + "MENU_LOAD", "LOAD");
                texts.Add(language + "MENU_CREDITS", "CREDITS");
                texts.Add(language + "MENU_EXIT", "EXIT");

                texts.Add(language + "MENUNEW_CHARACTERNAME", "Character Name");
                texts.Add(language + "MENUNEW_CREATE", "CREATE");
                texts.Add(language + "MENUNEW_BACK", "BACK");

                texts.Add(language + "MENULOAD_LOGIN", "LOGIN >>");
                texts.Add(language + "MENULOAD_BACK", "BACK");

                texts.Add(language + "MENUCREDITS_DEVELOPER", "Developer: Thiago Melo\nContact: thiagomelo@edu.unifor.br");
                texts.Add(language + "MENUCREDITS_BACK", "BACK");

                texts.Add(language + "START_NAMEGAME", "VAMPIRE SLAVE TACTICS");
                texts.Add(language + "START_DROPHUMANS", "DROP HUMANS");
                texts.Add(language + "START_CAMPAIN", "CAMPAIN");
                texts.Add(language + "START_MENU", "MENU");
                texts.Add(language + "START_CITY", "CITY");
                texts.Add(language + "START_ASYLUM", "ASYLUM");

                texts.Add(language + "MENUHUMANS_LISTHUMANS", "LIST HUMANS");
                texts.Add(language + "MENUHUMANS_NAME", "Name");
                texts.Add(language + "MENUHUMANS_JOB", "Job");
                texts.Add(language + "MENUHUMANS_ENABLED", "Enabled");
                texts.Add(language + "MENUHUMANS_DETAILS", "Details");
                texts.Add(language + "MENUHUMANS_BACK", "BACK");

                texts.Add(language + "MENU_C_BACK", "BACK");

                //################# STATES #######################################################################################
                texts.Add(language + "CAMPAIN_Choose Action", "Choose Action");
                texts.Add(language + "CAMPAIN_Confirm Skill", "Confirm Skill");
                texts.Add(language + "CAMPAIN_IA Player", "IA Player");
                texts.Add(language + "CAMPAIN_Loading", "Loading");
                texts.Add(language + "CAMPAIN_Move Selection", "Move Selection");
                texts.Add(language + "CAMPAIN_Roam", "Roam");
                texts.Add(language + "CAMPAIN_Skill Selection", "Skill Selection");
                texts.Add(language + "CAMPAIN_Skill Target", "Skill Target");
                texts.Add(language + "CAMPAIN_NO_UNIT", "No unit would be affected");

                //################# UI ACTIONS ###################################################################################
                texts.Add(language + "MOVE", "Move");
                texts.Add(language + "WAIT", "Wait");
                texts.Add(language + "ROAM", "Roam");
                texts.Add(language + "LEAVE", "Leave");

                //################# UI DIALOGS ###################################################################################
                texts.Add(language + "DIALOG_P1_1", en_us_textP1_1);
                texts.Add(language + "DIALOG_P1_2", en_us_textP1_2);
                texts.Add(language + "DIALOG_P1_NEXT", "Next");
                texts.Add(language + "DIALOG_P1_PREV", "Prev");

                texts.Add(language + "DIALOG_P2_1", en_us_textP2_1);
                texts.Add(language + "DIALOG_P2_NEXT", "Next");

                texts.Add(language + "DIALOG_P3_1", en_us_textP3_1);
                texts.Add(language + "DIALOG_P3_NEXT", "Next");

                texts.Add(language + "DIALOG_P4_1", en_us_textP4_1);
                texts.Add(language + "DIALOG_P4_NEXT", "Next");

                texts.Add(language + "DIALOG_P5_1", en_us_textP5_1);

                texts.Add(language + "MENUGAMEOVER_TEXT", en_us_textGameOver);
                texts.Add(language + "MENUGAMEOVER_MAINMENU", "MAIN MENU");

                //################# JOBS SKILLS  ###################################################################################
                texts.Add(language + "JOB_Bless", "Bless");
                texts.Add(language + "JOB_Esuna", "Esuna");
                texts.Add(language + "JOB_FireBall", "Fire Ball");
                texts.Add(language + "JOB_FireBreath", "Fire Breath");
                texts.Add(language + "JOB_FirePillar", "Fire Pillar");
                texts.Add(language + "JOB_FirstAid", "First Aid");
                texts.Add(language + "JOB_Lunge", "Lunge");
                texts.Add(language + "JOB_NormalAttack", "Normal Attack");
                texts.Add(language + "JOB_PoisonDart", "PoisonDart");
                texts.Add(language + "JOB_Rend", "Rend");
                texts.Add(language + "JOB_Restoration", "Restoration");
                texts.Add(language + "JOB_Change Job", "Change Job");

                break;

            case "fr-fr":

                texts.Add(language + "NEXT", "Ensuite");
                texts.Add(language + "VICTORY", "LA VICTOIRE");
                texts.Add(language + "LOSE", "PERDRE");
                texts.Add(language + "FINISH", "TERMINER");
                texts.Add(language + "LV_UP", "NIVEAU AVANCE");
                texts.Add(language + "Level", "Niveau");

                //################# LOBBY #######################################################################################
                texts.Add(language + "MAINCAMERA_NAMEGAME", "VAMPIRE SLAVE");

                texts.Add(language + "MENU_NEW", "NOUVEAU");
                texts.Add(language + "MENU_LOAD", "CHARGE");
                texts.Add(language + "MENU_CREDITS", "CRÉDITS");
                texts.Add(language + "MENU_EXIT", "SORTIE");

                texts.Add(language + "MENUNEW_CHARACTERNAME", "Le nom du personnage");
                texts.Add(language + "MENUNEW_CREATE", "CRÉER");
                texts.Add(language + "MENUNEW_BACK", "RETOUR");

                texts.Add(language + "MENULOAD_LOGIN", "S'IDENTIFIER");
                texts.Add(language + "MENULOAD_BACK", "RETOUR");

                texts.Add(language + "MENUCREDITS_DEVELOPER", "Développeuse: Thiago Melo\nContact: thiagomelo@edu.unifor.br");
                texts.Add(language + "MENUCREDITS_BACK", "RETOUR");

                texts.Add(language + "START_NAMEGAME", "VAMPIRE SLAVE TACTICS");
                texts.Add(language + "START_DROPHUMANS", "DROP HUMANS");
                texts.Add(language + "START_CAMPAIN", "CAMPAGNE");
                texts.Add(language + "START_MENU", "MENU");
                texts.Add(language + "START_CITY", "VILLE");
                texts.Add(language + "START_ASYLUM", "ASILE");

                texts.Add(language + "MENUHUMANS_LISTHUMANS", "LISTE DES HUMAINS");
                texts.Add(language + "MENUHUMANS_NAME", "Nom");
                texts.Add(language + "MENUHUMANS_JOB", "Emploi");
                texts.Add(language + "MENUHUMANS_ENABLED", "Activé");
                texts.Add(language + "MENUHUMANS_DETAILS", "Détails");
                texts.Add(language + "MENUHUMANS_BACK", "RETOUR");

                texts.Add(language + "MENU_C_BACK", "RETOUR");

                //################# STATES #######################################################################################
                texts.Add(language + "CAMPAIN_Choose Action", "Choisir Une Action");
                texts.Add(language + "CAMPAIN_Confirm Skill", "Confirmer la Compétence");
                texts.Add(language + "CAMPAIN_IA Player", "IA Player");
                texts.Add(language + "CAMPAIN_Loading", "Chargement");
                texts.Add(language + "CAMPAIN_Move Selection", "Déplacer la sélection");
                texts.Add(language + "CAMPAIN_Roam", "Errer");
                texts.Add(language + "CAMPAIN_Skill Selection", "Sélection des compétences");
                texts.Add(language + "CAMPAIN_Skill Target", "Compétence Cible");
                texts.Add(language + "CAMPAIN_NO_UNIT", "No unit would be affected");

                //################# UI ACTIONS ###################################################################################
                texts.Add(language + "MOVE", "Bouge Toi");
                texts.Add(language + "WAIT", "Attendez");
                texts.Add(language + "ROAM", "Errer");
                texts.Add(language + "LEAVE", "Partir");

                //################# UI DIALOGS ###################################################################################
                texts.Add(language + "DIALOG_P1_1", fr_fr_textP1_1);
                texts.Add(language + "DIALOG_P1_2", fr_fr_textP1_2);
                texts.Add(language + "DIALOG_P1_NEXT", "Ensuite");
                texts.Add(language + "DIALOG_P1_PREV", "Précédent");

                texts.Add(language + "DIALOG_P2_1", fr_fr_textP2_1);
                texts.Add(language + "DIALOG_P2_NEXT", "Ensuite");

                texts.Add(language + "DIALOG_P3_1", fr_fr_textP3_1);
                texts.Add(language + "DIALOG_P3_NEXT", "Ensuite");

                texts.Add(language + "DIALOG_P4_1", fr_fr_textP4_1);
                texts.Add(language + "DIALOG_P4_NEXT", "Ensuite");

                texts.Add(language + "DIALOG_P5_1", fr_fr_textP5_1);

                texts.Add(language + "MENUGAMEOVER_TEXT", fr_fr_textGameOver);
                texts.Add(language + "MENUGAMEOVER_MAINMENU", "MENU PRINCIPAL");

                //################# JOBS SKILLS ####################################################################################
                texts.Add(language + "JOB_Bless", "Bénisse");
                texts.Add(language + "JOB_Esuna", "Purifier");
                texts.Add(language + "JOB_FireBall", "Boule de feu");
                texts.Add(language + "JOB_FireBreath", "Souffle De Feu");
                texts.Add(language + "JOB_FirePillar", "Pilier de feu");
                texts.Add(language + "JOB_FirstAid", "Premiers secours");
                texts.Add(language + "JOB_Lunge", "Fente");
                texts.Add(language + "JOB_NormalAttack", "Attaque normale");
                texts.Add(language + "JOB_PoisonDart", "Fléchette de poison");
                texts.Add(language + "JOB_Rend", "Empoisonner");
                texts.Add(language + "JOB_Restoration", "Traiteur");
                texts.Add(language + "JOB_Change Job", "Changer de travail");

                break;
        }
    }

    public string GetTexto(string constante)
    {
        string result;
        texts.TryGetValue(languageAtual + constante, out result);

        return result;
    }

    //TEXTOS INTRODUTÓRIOS DAS BATALHAS

    //FASE 1
    string pt_br_textP1_1 = "O poderoso vampiro Monçada, matou o senhor feudal das terras de Black Gold e escravisou seus habitantes.\n\n" +
                            "Na promessa de dinheiro e poder, ele forçou os habitantes a tomarem seu sangue, forçando assim um laço de escravidão mistico, a tal ponto que as ordens do mestre, passam a ser missões divinas a serem cumpridas sem qualquer questionamento.\n\n" +
                            "Você tambem sucumbiu ao laço de escravidão do vampiro, mas durante uma missão ao feudo visinho, você conheceu um grande mago Mark, que ao perceber o mal acomedido aos aldeões, jurou te acompanhar numa saga até o castelo e por um fim ao laço de escravidão.\n\n" +
                            "O mago removeu temporariamente o seu vinculo com o Vampiro, te garantindo uma grande oportunidade de salvar sua terra natal.\n\n" +
                            "Corra guerreiro, siga na direção do castelo do mestre vampiro e liberte os aldeões desta praga.";

    string en_us_textP1_1 = "The mighty vampire Moncada killed the feudal lord of the lands of Black Gold and enslaved its inhabitants.\n\n" +
                            "In the promise of money and power, he forced the inhabitants to take their blood, thus forcing a bond of mystical slavery to the point that the master's orders became divine missions to be fulfilled without question.\n\n" +
                            "You also succumbed to the vampire's bond of bondage, but during a mission to the neighboring fiefdom, you met a great wizard Mark, who, upon realizing the harm done to the villagers, vowed to accompany you in a saga to the castle and to end the bondage bond.\n\n" +
                            "The magician has temporarily removed his bond with the Vampire, providing you with a great opportunity to save his homeland.\n\n" +
                            "Run warrior, head towards the vampire master's castle and free the villagers from this plague.";

    string fr_fr_textP1_1 = "Le puissant vampire Moncada a tué le seigneur féodal des terres de l'or noir et asservi ses habitants.\n\n" +
                            "Dans la promesse de l'argent et du pouvoir, il a forcé les habitants à prendre leur sang, forçant ainsi un lien d'esclavage mystique au point que les ordres du maître deviennent des missions divines à remplir sans aucun doute.\n\n" +
                            "Vous avez également succombé au lien de servitude du vampire, mais lors d'une mission dans le fief voisin, vous avez rencontré un grand sorcier, Mark, qui, se rendant compte du mal causé aux villageois, s'était engagé à vous accompagner dans une saga du château et à mettre fin au lien de servitude.\n\n" +
                            "Le magicien a temporairement supprimé son lien avec le vampire, vous offrant ainsi une excellente occasion de sauver sa patrie.\n\n" +
                            "Courez guerrier, dirigez-vous vers le château du maître des vampires et libérez les villageois de cette peste.";

    string pt_br_textP1_2 = "Quem ousa levantar sua lâmina contra o mestre? Irá  experimentar a força herdada dele!";

    string en_us_textP1_2 = "Who dares raise his blade against the master? You will experience his inherited strength!";

    string fr_fr_textP1_2 = "Qui ose lever sa lame contre le maître? Vous ferez l'expérience de sa force héritée!";


    //FASE 2
    string pt_br_textP2_1 = "O rompante escravo e seu bruxo acham que podem enfrentar o Mestre da noite? Ele tudo vê, tudo sabe e ja escolheu o seu destino que será tombar perante minha lâmina.";
    string en_us_textP2_1 = "Do the breaking slave and his wizard think they can face the Master of the night? He sees everything, knows everything and has already chosen his destiny, which will fall before my blade.";
    string fr_fr_textP2_1 = "L'esclave qui se brise et son sorcier pensent-ils pouvoir faire face au Maître de la nuit? Il voit tout, sait tout et a déjà choisi son destin, qui va tomber avant ma lame.";

    //FASE 3
    string pt_br_textP3_1 = "Sua audácia será um grande triunfo aos pés do mestre dessas terras. Sua derrocada será o exemplo a todos que ousarem se levantar contra o meu senhor.";
    string en_us_textP3_1 = "Your boldness will be a great triumph at the feet of the master of these lands. Your overthrow will be an example to all who dare to rise up against my lord.";
    string fr_fr_textP3_1 = "Votre audace sera un grand triomphe aux pieds du maître de ces terres. Votre renversement sera un exemple pour tous ceux qui osent se soulever contre mon seigneur.";

    //FASE 4
    string pt_br_textP4_1 = "Há muito tempo não tenho prazer em derrotar alguém... venha e mostre a força que vocês têm para ter chegado até aqui. Sintam a força que vem de meu mestre!";
    string en_us_textP4_1 = "I have not had pleasure in defeating anyone for a long time ... come and show the strength you have to have come here. Feel the strength that comes from my master!";
    string fr_fr_textP4_1 = "Je n'ai eu aucun plaisir à vaincre qui que ce soit depuis longtemps ... viens et montre la force que tu dois être venu ici. Sentez la force qui vient de mon maître!";

    //FASE 5
    string pt_br_textP5_1 = "Criança mal agradecida... Se deseja tanto sua liberdade, saiba que só a terá com minha derrota. Venha e mostre o que aprendeu contra aquele que reina na noite!";
    string en_us_textP5_1 = "Grateful child ... If you want your freedom so much, know that you will only have it with my defeat. Come and show what you have learned against the one who reigns in the night!";
    string fr_fr_textP5_1 = "Enfant reconnaissant ... Si tu veux tellement ta liberté, sache que tu ne l'auras qu'avec ma défaite. Viens montrer ce que tu as appris contre celui qui règne la nuit!";

    //GAMEOVER
    string pt_br_textGameOver = "Parabéns, o elo maligno que o mantinha submisso ao vampiro mestre foi rompido.\n\n" +
                                "Agora seja dono do seu próprio destino e escolha o seu novo papel nesse mundo de trevas.";
    string en_us_textGameOver = "Congratulations, the evil link that kept you submissive to the master vampire has been broken.\n\n" +
                                "Now own your own destiny and choose your new role in this world of darkness.";
    string fr_fr_textGameOver = "Félicitations, le lien pervers qui vous a tenus soumis au maître vampire a été brisé.\n\n" +
                                "Maintenant, détenez votre propre destin et choisissez votre nouveau rôle dans ce monde de ténèbres.";

}
