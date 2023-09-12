using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.Threading;

public class main : MonoBehaviour
{
    string team_1_long = "Tima Belorusskih", team_1_short = "TIB",
    team_2_long = "Corona Extra (white)", team_2_short = "CEW",
    team_3_long = "Krynica", team_3_short = "KRY",
    team_4_long = "Carlsberg (black)", team_4_short = "CBB",
    team_5_long = "BECK'S", team_5_short = "BEC",
    team_6_long = "Kuba", team_6_short = "KUB",
    team_7_long = "San Pellegrino (blue)", team_7_short = "SPB",
    team_8_long = "Bobrov", team_8_short = "BBR",
    team_9_long = "Nevskoe ISE", team_9_short = "NEV",
    team_10_long = "Frida", team_10_short = "FRD",
    team_11_long = "Carlsberg (green)", team_11_short = "CBG",
    team_12_long = "Birra Peroni (red)", team_12_short = "BPR",
    team_13_long = "Coca-cola", team_13_short = "COC",
    team_14_long = "Baltika (beige)", team_14_short = "BTB",
    team_15_long = "Heineken (green)", team_15_short = "HEG",
    team_16_long = "Miller", team_16_short = "MLR",
    team_17_long = "Heineken (white)", team_17_short = "HEW",
    team_18_long = "Sprite", team_18_short = "SPR",
    team_19_long = "Mills", team_19_short = "MLS",
    team_20_long = "Baltika (333)", team_20_short = "BT3",
    team_21_long = "Birra Moretti", team_21_short = "BIM",
    team_22_long = "San Pellegrino (col)", team_22_short = "SPC",
    team_23_long = "Kozel", team_23_short = "KZL",
    team_24_long = "Green beer", team_24_short = "GRB",
    team_25_long = "Baltika (224)", team_25_short = "BT2",
    team_26_long = "LĀČPLĒSIS", team_26_short = "LĀČ",
    team_27_long = "Sorgente Fontesana", team_27_short = "SOF",
    team_28_long = "BUDWEISER", team_28_short = "BUD",
    team_29_long = "Corona Extra (orange)", team_29_short = "CEO",
    team_30_long = "Birra Peroni (white)", team_30_short = "BPW";

    Text[,] groups_text;
    Text[,] points_text;
    Text[,] matches_text;
    Text[,] differences_text;
    Text[,] goals_text;

    string[,] sides_and_tours;

    int[] r_nums;
    const int NUMBER_OF_TEAMS = 30;
    const int NUMBER_OF_GROUPS = 6;
    const int NUMBER_OF_TRACKS = 22;

    puuck pk1_scr, pk2_scr, pk3_scr, pk4_scr, pk5_scr, pk6_scr;

    GameObject ar1_lf1, ar1_lf2, ar1_rf1, ar1_rf2,
               ar2_lf1, ar2_lf2, ar2_rf1, ar2_rf2,
               ar3_lf1, ar3_lf2, ar3_rf1, ar3_rf2,
               ar4_lf1, ar4_lf2, ar4_rf1, ar4_rf2,
               ar5_lf1, ar5_lf2, ar5_rf1, ar5_rf2,
               ar6_lf1, ar6_lf2, ar6_rf1, ar6_rf2,
               ar1_lgk, ar2_lgk, ar3_lgk, ar4_lgk, ar5_lgk, ar6_lgk,
               ar1_rgk, ar2_rgk, ar3_rgk, ar4_rgk, ar5_rgk, ar6_rgk,
               ar1__fl, ar2__fl, ar3__fl, ar4__fl, ar5__fl, ar6__fl;

    Camera[] close_cams, obs_cams;
    Canvas canvas_observer, canvas_playoff_observer;

    Text score_a_l_buf, score_a_r_buf, score_b_l_buf, score_b_r_buf, score_c_l_buf, score_c_r_buf,
         score_d_l_buf, score_d_r_buf, score_e_l_buf, score_e_r_buf, score_f_l_buf, score_f_r_buf,
         ot_a_buf, ot_b_buf, ot_c_buf, ot_d_buf, ot_e_buf, ot_f_buf,
         time_a_buf, time_b_buf, time_c_buf, time_d_buf, time_e_buf, time_f_buf;

    AI ar1_lf1_ai, ar1_lf2_ai, ar1_rf1_ai, ar1_rf2_ai,
       ar2_lf1_ai, ar2_lf2_ai, ar2_rf1_ai, ar2_rf2_ai,
       ar3_lf1_ai, ar3_lf2_ai, ar3_rf1_ai, ar3_rf2_ai,
       ar4_lf1_ai, ar4_lf2_ai, ar4_rf1_ai, ar4_rf2_ai,
       ar5_lf1_ai, ar5_lf2_ai, ar5_rf1_ai, ar5_rf2_ai,
       ar6_lf1_ai, ar6_lf2_ai, ar6_rf1_ai, ar6_rf2_ai;

    AI_gk ar1_lgk_ai, ar2_lgk_ai, ar3_lgk_ai, ar4_lgk_ai, ar5_lgk_ai, ar6_lgk_ai,
          ar1_rgk_ai, ar2_rgk_ai, ar3_rgk_ai, ar4_rgk_ai, ar5_rgk_ai, ar6_rgk_ai;

    int forwards = 1;//если изменишь, то тоже изменить в puuck
    float timer = 30f;
    int tour = 1;
    bool once_a = false, once_b = false, once_c = false, once_d = false, once_e = false, once_f = false;
    bool space = false;

    class Team
    {
        public string name;
        public string short_name;
        public int points;
        public int matches;
        public int[] vanquished;
        public int number;
        public int difference;
        public int goals;
        public Material mat_f1;
        public Material mat_f2;
        public Material mat_gk;
        public Material mat__f;
    };

    Team team_a1 = new Team();
    Team team_a2 = new Team();
    Team team_a3 = new Team();
    Team team_a4 = new Team();
    Team team_a5 = new Team();

    Team team_b1 = new Team();
    Team team_b2 = new Team();
    Team team_b3 = new Team();
    Team team_b4 = new Team();
    Team team_b5 = new Team();

    Team team_c1 = new Team();
    Team team_c2 = new Team();
    Team team_c3 = new Team();
    Team team_c4 = new Team();
    Team team_c5 = new Team();

    Team team_d1 = new Team();
    Team team_d2 = new Team();
    Team team_d3 = new Team();
    Team team_d4 = new Team();
    Team team_d5 = new Team();

    Team team_e1 = new Team();
    Team team_e2 = new Team();
    Team team_e3 = new Team();
    Team team_e4 = new Team();
    Team team_e5 = new Team();

    Team team_f1 = new Team();
    Team team_f2 = new Team();
    Team team_f3 = new Team();
    Team team_f4 = new Team();
    Team team_f5 = new Team();

    Team[,] teams;
    Team[,] teams_sort;
    Team[,] playoff_teams;

    char[] letters;

    int left_num = 0, right_num = 1;
    int k;

    int current_cam = 6;

    float tr_timer = 22f;
    int tr_counter = 0;
    int playlist_counter = 0;
    bool pause_bool = true;
    public AudioClip track_1, track_2, track_3, track_4, track_5, track_6, track_7, track_8, track_9, track_10,
                     track_11, track_12, track_13, track_14, track_15, track_16, track_17, track_18, track_19, track_20, track_21, track_22;
    int[] tracks_queue;
    AudioClip[] playlist;
    AudioClip[] playlist_buffer;
    AudioSource audio;

    struct Playoff_pair_text
    {
        public Text[] team_texts;
        public Text[] general_score_texts;
        public Text[] match_score_texts;
        public Text[] match_time_texts;
    };

    Playoff_pair_text[] playoff_pairs_text;
    int[] playoff_pair_nums;
    int playoff_pair_match_num = 0;
    int[] second_teams_random_array;
    bool first_seeing_playoff = true;
    int host, guest;
    float fsp_timer = 1;
    bool last_playoff_game = false;

    void Awake()
    {
        pk1_scr = GameObject.Find("/Arena (1)/Puck").GetComponent<puuck>();
        pk2_scr = GameObject.Find("/Arena (2)/Puck").GetComponent<puuck>();
        pk3_scr = GameObject.Find("/Arena (3)/Puck").GetComponent<puuck>();
        pk4_scr = GameObject.Find("/Arena (4)/Puck").GetComponent<puuck>();
        pk5_scr = GameObject.Find("/Arena (5)/Puck").GetComponent<puuck>();
        pk6_scr = GameObject.Find("/Arena (6)/Puck").GetComponent<puuck>();

        pk1_scr.score_text2 = GameObject.Find("o1_score_text").GetComponent<Text>();
        pk1_scr.time_text2 = GameObject.Find("o1_time_text").GetComponent<Text>();
        pk1_scr.ce_team_text2 = GameObject.Find("o1_ce_team_text").GetComponent<Text>();
        pk1_scr.k_team_text2 = GameObject.Find("o1_k_team_text").GetComponent<Text>();
        pk1_scr.time_number_text2 = GameObject.Find("o1_time_number_text").GetComponent<Text>();

        pk2_scr.score_text2 = GameObject.Find("o2_score_text").GetComponent<Text>();
        pk2_scr.time_text2 = GameObject.Find("o2_time_text").GetComponent<Text>();
        pk2_scr.ce_team_text2 = GameObject.Find("o2_ce_team_text").GetComponent<Text>();
        pk2_scr.k_team_text2 = GameObject.Find("o2_k_team_text").GetComponent<Text>();
        pk2_scr.time_number_text2 = GameObject.Find("o2_time_number_text").GetComponent<Text>();

        pk3_scr.score_text2 = GameObject.Find("o3_score_text").GetComponent<Text>();
        pk3_scr.time_text2 = GameObject.Find("o3_time_text").GetComponent<Text>();
        pk3_scr.ce_team_text2 = GameObject.Find("o3_ce_team_text").GetComponent<Text>();
        pk3_scr.k_team_text2 = GameObject.Find("o3_k_team_text").GetComponent<Text>();
        pk3_scr.time_number_text2 = GameObject.Find("o3_time_number_text").GetComponent<Text>();

        pk4_scr.score_text2 = GameObject.Find("o4_score_text").GetComponent<Text>();
        pk4_scr.time_text2 = GameObject.Find("o4_time_text").GetComponent<Text>();
        pk4_scr.ce_team_text2 = GameObject.Find("o4_ce_team_text").GetComponent<Text>();
        pk4_scr.k_team_text2 = GameObject.Find("o4_k_team_text").GetComponent<Text>();
        pk4_scr.time_number_text2 = GameObject.Find("o4_time_number_text").GetComponent<Text>();

        pk5_scr.score_text2 = GameObject.Find("o5_score_text").GetComponent<Text>();
        pk5_scr.time_text2 = GameObject.Find("o5_time_text").GetComponent<Text>();
        pk5_scr.ce_team_text2 = GameObject.Find("o5_ce_team_text").GetComponent<Text>();
        pk5_scr.k_team_text2 = GameObject.Find("o5_k_team_text").GetComponent<Text>();
        pk5_scr.time_number_text2 = GameObject.Find("o5_time_number_text").GetComponent<Text>();

        pk6_scr.score_text2 = GameObject.Find("o6_score_text").GetComponent<Text>();
        pk6_scr.time_text2 = GameObject.Find("o6_time_text").GetComponent<Text>();
        pk6_scr.ce_team_text2 = GameObject.Find("o6_ce_team_text").GetComponent<Text>();
        pk6_scr.k_team_text2 = GameObject.Find("o6_k_team_text").GetComponent<Text>();
        pk6_scr.time_number_text2 = GameObject.Find("o6_time_number_text").GetComponent<Text>();


        pk1_scr.score_text = GameObject.Find("/Canvas (1)/score_text").GetComponent<Text>();
        pk1_scr.time_text = GameObject.Find("/Canvas (1)/time_text").GetComponent<Text>();
        pk1_scr.ce_team_text = GameObject.Find("/Canvas (1)/ce_team_text").GetComponent<Text>();
        pk1_scr.k_team_text = GameObject.Find("/Canvas (1)/k_team_text").GetComponent<Text>();
        pk1_scr.time_number_text = GameObject.Find("/Canvas (1)/time_number_text").GetComponent<Text>();

        pk2_scr.score_text = GameObject.Find("/Canvas (2)/score_text").GetComponent<Text>();
        pk2_scr.time_text = GameObject.Find("/Canvas (2)/time_text").GetComponent<Text>();
        pk2_scr.ce_team_text = GameObject.Find("/Canvas (2)/ce_team_text").GetComponent<Text>();
        pk2_scr.k_team_text = GameObject.Find("/Canvas (2)/k_team_text").GetComponent<Text>();
        pk2_scr.time_number_text = GameObject.Find("/Canvas (2)/time_number_text").GetComponent<Text>();

        pk3_scr.score_text = GameObject.Find("/Canvas (3)/score_text").GetComponent<Text>();
        pk3_scr.time_text = GameObject.Find("/Canvas (3)/time_text").GetComponent<Text>();
        pk3_scr.ce_team_text = GameObject.Find("/Canvas (3)/ce_team_text").GetComponent<Text>();
        pk3_scr.k_team_text = GameObject.Find("/Canvas (3)/k_team_text").GetComponent<Text>();
        pk3_scr.time_number_text = GameObject.Find("/Canvas (3)/time_number_text").GetComponent<Text>();

        pk4_scr.score_text = GameObject.Find("/Canvas (4)/score_text").GetComponent<Text>();
        pk4_scr.time_text = GameObject.Find("/Canvas (4)/time_text").GetComponent<Text>();
        pk4_scr.ce_team_text = GameObject.Find("/Canvas (4)/ce_team_text").GetComponent<Text>();
        pk4_scr.k_team_text = GameObject.Find("/Canvas (4)/k_team_text").GetComponent<Text>();
        pk4_scr.time_number_text = GameObject.Find("/Canvas (4)/time_number_text").GetComponent<Text>();

        pk5_scr.score_text = GameObject.Find("/Canvas (5)/score_text").GetComponent<Text>();
        pk5_scr.time_text = GameObject.Find("/Canvas (5)/time_text").GetComponent<Text>();
        pk5_scr.ce_team_text = GameObject.Find("/Canvas (5)/ce_team_text").GetComponent<Text>();
        pk5_scr.k_team_text = GameObject.Find("/Canvas (5)/k_team_text").GetComponent<Text>();
        pk5_scr.time_number_text = GameObject.Find("/Canvas (5)/time_number_text").GetComponent<Text>();

        pk6_scr.score_text = GameObject.Find("/Canvas (6)/score_text").GetComponent<Text>();
        pk6_scr.time_text = GameObject.Find("/Canvas (6)/time_text").GetComponent<Text>();
        pk6_scr.ce_team_text = GameObject.Find("/Canvas (6)/ce_team_text").GetComponent<Text>();
        pk6_scr.k_team_text = GameObject.Find("/Canvas (6)/k_team_text").GetComponent<Text>();
        pk6_scr.time_number_text = GameObject.Find("/Canvas (6)/time_number_text").GetComponent<Text>();

        pk1_scr.enabled = false;
        pk2_scr.enabled = false;
        pk3_scr.enabled = false;
        pk4_scr.enabled = false;
        pk5_scr.enabled = false;
        pk6_scr.enabled = false;

        pk1_scr.number_of_arena = 1;
        pk2_scr.number_of_arena = 2;
        pk3_scr.number_of_arena = 3;
        pk4_scr.number_of_arena = 4;
        pk5_scr.number_of_arena = 5;
        pk6_scr.number_of_arena = 6;

        playoff_pairs_text = new Playoff_pair_text[6];
        for (int i = 0; i < 6; i++)
        {
            playoff_pairs_text[i].team_texts = new Text[2] { GameObject.Find("left name (" + (i + 1) + ")").GetComponent<Text>(),
                                                             GameObject.Find("right name (" + (i + 1) + ")").GetComponent<Text>() };
            playoff_pairs_text[i].general_score_texts = new Text[2] { GameObject.Find("left score (" + (i + 1) + ")").GetComponent<Text>(),
                                                                      GameObject.Find("right score (" + (i + 1) + ")").GetComponent<Text>() };
            playoff_pairs_text[i].match_score_texts = new Text[3] { GameObject.Find("first score (" + (i + 1) + ")").GetComponent<Text>(),
                                                                    GameObject.Find("second score (" + (i + 1) + ")").GetComponent<Text>(),
                                                                    GameObject.Find("third score (" + (i + 1) + ")").GetComponent<Text>() };
            playoff_pairs_text[i].match_time_texts = new Text[3] { GameObject.Find("first status (" + (i + 1) + ")").GetComponent<Text>(),
                                                                   GameObject.Find("second status (" + (i + 1) + ")").GetComponent<Text>(),
                                                                   GameObject.Find("third status (" + (i + 1) + ")").GetComponent<Text>() };
        }

        pk1_scr.score_text3 = playoff_pairs_text[0].match_score_texts[0];
        pk2_scr.score_text3 = playoff_pairs_text[1].match_score_texts[0];
    }

    void Start()
    {
        playoff_pair_nums = new int[2] { 0, 1 };

        close_cams = new Camera[8];
        obs_cams = new Camera[6];
        for (int i = 0; i < 6; i++)
        {
            close_cams[i] = GameObject.Find("/Arena (" + (i + 1) + ")/Camera").GetComponent<Camera>();
            obs_cams[i] = GameObject.Find("/Arena (" + (i + 1) + ")/Camera (1)").GetComponent<Camera>();
        }
        close_cams[6] = GameObject.Find("Standings camera").GetComponent<Camera>();
        canvas_observer = GameObject.Find("Canvas Observer").GetComponent<Canvas>();
        close_cams[7] = GameObject.Find("Play-off camera").GetComponent<Camera>();
        canvas_playoff_observer = GameObject.Find("Canvas play-off observer").GetComponent<Canvas>();

        second_teams_random_array = new int[NUMBER_OF_GROUPS];
        for (int i = 0; i < NUMBER_OF_GROUPS; i++) { second_teams_random_array[i] = -1; }

        r_nums = new int[NUMBER_OF_TEAMS];
        for (int i = 0; i < NUMBER_OF_TEAMS; i++) { r_nums[i] = -1; }

        letters = new char[6] { 'a', 'b', 'c', 'd', 'e', 'f' };

        teams = new Team[6, 5] { { team_a1, team_a2, team_a3, team_a4, team_a5 },
                                 { team_b1, team_b2, team_b3, team_b4, team_b5 },
                                 { team_c1, team_c2, team_c3, team_c4, team_c5 },
                                 { team_d1, team_d2, team_d3, team_d4, team_d5 },
                                 { team_e1, team_e2, team_e3, team_e4, team_e5 },
                                 { team_f1, team_f2, team_f3, team_f4, team_f5 } };

        teams_sort = new Team[6, 5] { { team_a1, team_a2, team_a3, team_a4, team_a5 },
                                 { team_b1, team_b2, team_b3, team_b4, team_b5 },
                                 { team_c1, team_c2, team_c3, team_c4, team_c5 },
                                 { team_d1, team_d2, team_d3, team_d4, team_d5 },
                                 { team_e1, team_e2, team_e3, team_e4, team_e5 },
                                 { team_f1, team_f2, team_f3, team_f4, team_f5 } };

        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                setter(teams[i, j], j + 1);
            }
        }

        ar1_lf1 = GameObject.Find("/Arena (1)/Corona Extra forward (1)");
        ar1_lf2 = GameObject.Find("/Arena (1)/Corona Extra forward (2)");
        ar1_lgk = GameObject.Find("/Arena (1)/Corona Extra goalkeeper");
        ar1_rf1 = GameObject.Find("/Arena (1)/Krynica forward (1)");
        ar1_rf2 = GameObject.Find("/Arena (1)/Krynica forward (2)");
        ar1_rgk = GameObject.Find("/Arena (1)/Krynica goalkeeper");
        ar2_lf1 = GameObject.Find("/Arena (2)/Corona Extra forward (1)");
        ar2_lf2 = GameObject.Find("/Arena (2)/Corona Extra forward (2)");
        ar2_lgk = GameObject.Find("/Arena (2)/Corona Extra goalkeeper");
        ar2_rf1 = GameObject.Find("/Arena (2)/Krynica forward (1)");
        ar2_rf2 = GameObject.Find("/Arena (2)/Krynica forward (2)");
        ar2_rgk = GameObject.Find("/Arena (2)/Krynica goalkeeper");
        ar3_lf1 = GameObject.Find("/Arena (3)/Corona Extra forward (1)");
        ar3_lf2 = GameObject.Find("/Arena (3)/Corona Extra forward (2)");
        ar3_lgk = GameObject.Find("/Arena (3)/Corona Extra goalkeeper");
        ar3_rf1 = GameObject.Find("/Arena (3)/Krynica forward (1)");
        ar3_rf2 = GameObject.Find("/Arena (3)/Krynica forward (2)");
        ar3_rgk = GameObject.Find("/Arena (3)/Krynica goalkeeper");
        ar4_lf1 = GameObject.Find("/Arena (4)/Corona Extra forward (1)");
        ar4_lf2 = GameObject.Find("/Arena (4)/Corona Extra forward (2)");
        ar4_lgk = GameObject.Find("/Arena (4)/Corona Extra goalkeeper");
        ar4_rf1 = GameObject.Find("/Arena (4)/Krynica forward (1)");
        ar4_rf2 = GameObject.Find("/Arena (4)/Krynica forward (2)");
        ar4_rgk = GameObject.Find("/Arena (4)/Krynica goalkeeper");
        ar5_lf1 = GameObject.Find("/Arena (5)/Corona Extra forward (1)");
        ar5_lf2 = GameObject.Find("/Arena (5)/Corona Extra forward (2)");
        ar5_lgk = GameObject.Find("/Arena (5)/Corona Extra goalkeeper");
        ar5_rf1 = GameObject.Find("/Arena (5)/Krynica forward (1)");
        ar5_rf2 = GameObject.Find("/Arena (5)/Krynica forward (2)");
        ar5_rgk = GameObject.Find("/Arena (5)/Krynica goalkeeper");
        ar6_lf1 = GameObject.Find("/Arena (6)/Corona Extra forward (1)");
        ar6_lf2 = GameObject.Find("/Arena (6)/Corona Extra forward (2)");
        ar6_lgk = GameObject.Find("/Arena (6)/Corona Extra goalkeeper");
        ar6_rf1 = GameObject.Find("/Arena (6)/Krynica forward (1)");
        ar6_rf2 = GameObject.Find("/Arena (6)/Krynica forward (2)");
        ar6_rgk = GameObject.Find("/Arena (6)/Krynica goalkeeper");

        ar1__fl = GameObject.Find("/Arena (1)/Floor");
        ar2__fl = GameObject.Find("/Arena (2)/Floor");
        ar3__fl = GameObject.Find("/Arena (3)/Floor");
        ar4__fl = GameObject.Find("/Arena (4)/Floor");
        ar5__fl = GameObject.Find("/Arena (5)/Floor");
        ar6__fl = GameObject.Find("/Arena (6)/Floor");

        ar1_lf1_ai = GameObject.Find("/Arena (1)/Corona Extra forward (1)").GetComponent<AI>();
        ar1_lf2_ai = GameObject.Find("/Arena (1)/Corona Extra forward (2)").GetComponent<AI>();
        ar1_lgk_ai = GameObject.Find("/Arena (1)/Corona Extra goalkeeper").GetComponent<AI_gk>();
        ar1_rf1_ai = GameObject.Find("/Arena (1)/Krynica forward (1)").GetComponent<AI>();
        ar1_rf2_ai = GameObject.Find("/Arena (1)/Krynica forward (2)").GetComponent<AI>();
        ar1_rgk_ai = GameObject.Find("/Arena (1)/Krynica goalkeeper").GetComponent<AI_gk>();
        ar2_lf1_ai = GameObject.Find("/Arena (2)/Corona Extra forward (1)").GetComponent<AI>();
        ar2_lf2_ai = GameObject.Find("/Arena (2)/Corona Extra forward (2)").GetComponent<AI>();
        ar2_lgk_ai = GameObject.Find("/Arena (2)/Corona Extra goalkeeper").GetComponent<AI_gk>();
        ar2_rf1_ai = GameObject.Find("/Arena (2)/Krynica forward (1)").GetComponent<AI>();
        ar2_rf2_ai = GameObject.Find("/Arena (2)/Krynica forward (2)").GetComponent<AI>();
        ar2_rgk_ai = GameObject.Find("/Arena (2)/Krynica goalkeeper").GetComponent<AI_gk>();
        ar3_lf1_ai = GameObject.Find("/Arena (3)/Corona Extra forward (1)").GetComponent<AI>();
        ar3_lf2_ai = GameObject.Find("/Arena (3)/Corona Extra forward (2)").GetComponent<AI>();
        ar3_lgk_ai = GameObject.Find("/Arena (3)/Corona Extra goalkeeper").GetComponent<AI_gk>();
        ar3_rf1_ai = GameObject.Find("/Arena (3)/Krynica forward (1)").GetComponent<AI>();
        ar3_rf2_ai = GameObject.Find("/Arena (3)/Krynica forward (2)").GetComponent<AI>();
        ar3_rgk_ai = GameObject.Find("/Arena (3)/Krynica goalkeeper").GetComponent<AI_gk>();
        ar4_lf1_ai = GameObject.Find("/Arena (4)/Corona Extra forward (1)").GetComponent<AI>();
        ar4_lf2_ai = GameObject.Find("/Arena (4)/Corona Extra forward (2)").GetComponent<AI>();
        ar4_lgk_ai = GameObject.Find("/Arena (4)/Corona Extra goalkeeper").GetComponent<AI_gk>();
        ar4_rf1_ai = GameObject.Find("/Arena (4)/Krynica forward (1)").GetComponent<AI>();
        ar4_rf2_ai = GameObject.Find("/Arena (4)/Krynica forward (2)").GetComponent<AI>();
        ar4_rgk_ai = GameObject.Find("/Arena (4)/Krynica goalkeeper").GetComponent<AI_gk>();
        ar5_lf1_ai = GameObject.Find("/Arena (5)/Corona Extra forward (1)").GetComponent<AI>();
        ar5_lf2_ai = GameObject.Find("/Arena (5)/Corona Extra forward (2)").GetComponent<AI>();
        ar5_lgk_ai = GameObject.Find("/Arena (5)/Corona Extra goalkeeper").GetComponent<AI_gk>();
        ar5_rf1_ai = GameObject.Find("/Arena (5)/Krynica forward (1)").GetComponent<AI>();
        ar5_rf2_ai = GameObject.Find("/Arena (5)/Krynica forward (2)").GetComponent<AI>();
        ar5_rgk_ai = GameObject.Find("/Arena (5)/Krynica goalkeeper").GetComponent<AI_gk>();
        ar6_lf1_ai = GameObject.Find("/Arena (6)/Corona Extra forward (1)").GetComponent<AI>();
        ar6_lf2_ai = GameObject.Find("/Arena (6)/Corona Extra forward (2)").GetComponent<AI>();
        ar6_lgk_ai = GameObject.Find("/Arena (6)/Corona Extra goalkeeper").GetComponent<AI_gk>();
        ar6_rf1_ai = GameObject.Find("/Arena (6)/Krynica forward (1)").GetComponent<AI>();
        ar6_rf2_ai = GameObject.Find("/Arena (6)/Krynica forward (2)").GetComponent<AI>();
        ar6_rgk_ai = GameObject.Find("/Arena (6)/Krynica goalkeeper").GetComponent<AI_gk>();

        ar1_lf1_ai.enabled = false;
        ar1_lf2_ai.enabled = false;
        ar1_lgk_ai.enabled = false;
        ar1_rf1_ai.enabled = false;
        ar1_rf2_ai.enabled = false;
        ar1_rgk_ai.enabled = false;
        ar2_lf1_ai.enabled = false;
        ar2_lf2_ai.enabled = false;
        ar2_lgk_ai.enabled = false;
        ar2_rf1_ai.enabled = false;
        ar2_rf2_ai.enabled = false;
        ar2_rgk_ai.enabled = false;
        ar3_lf1_ai.enabled = false;
        ar3_lf2_ai.enabled = false;
        ar3_lgk_ai.enabled = false;
        ar3_rf1_ai.enabled = false;
        ar3_rf2_ai.enabled = false;
        ar3_rgk_ai.enabled = false;
        ar4_lf1_ai.enabled = false;
        ar4_lf2_ai.enabled = false;
        ar4_lgk_ai.enabled = false;
        ar4_rf1_ai.enabled = false;
        ar4_rf2_ai.enabled = false;
        ar4_rgk_ai.enabled = false;
        ar5_lf1_ai.enabled = false;
        ar5_lf2_ai.enabled = false;
        ar5_lgk_ai.enabled = false;
        ar5_rf1_ai.enabled = false;
        ar5_rf2_ai.enabled = false;
        ar5_rgk_ai.enabled = false;
        ar6_lf1_ai.enabled = false;
        ar6_lf2_ai.enabled = false;
        ar6_lgk_ai.enabled = false;
        ar6_rf1_ai.enabled = false;
        ar6_rf2_ai.enabled = false;
        ar6_rgk_ai.enabled = false;

        groups_text = new Text[6, 5];
        points_text = new Text[6, 5];
        matches_text = new Text[6, 5];
        differences_text = new Text[6, 5];
        goals_text = new Text[6, 5];
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                groups_text[i, j] = GameObject.Find("group_" + letters[i] + " (" + (j + 1) + ")").GetComponent<Text>();
                points_text[i, j] = GameObject.Find("Pts gr_" + letters[i] + " (" + (j + 1) + ")").GetComponent<Text>();
                matches_text[i, j] = GameObject.Find("Mat gr_" + letters[i] + " (" + (j + 1) + ")").GetComponent<Text>();
                differences_text[i, j] = GameObject.Find("Dif gr_" + letters[i] + " (" + (j + 1) + ")").GetComponent<Text>();
                goals_text[i, j] = GameObject.Find("Gls gr_" + letters[i] + " (" + (j + 1) + ")").GetComponent<Text>();
            }
        }

        sides_and_tours = new string[4, 5] { { "_l (1)", "_r (1)", "_l (2)", "_r (2)", "_l (3)" },
                                                          { "_r (3)", "_l (4)", "_r (4)", "_l (5)", "_r (5)" },
                                                          { "_l (6)", "_l (7)", "_r (6)", "_r (7)", "_r (8)" },
                                                          { "_r (9)", "_r (10)", "_l (8)", "_l (9)", "_l (10)" } };

        k = 0;
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                r_nums[k] = foo_rand(r_nums, NUMBER_OF_TEAMS);

                groups_text[i, j].text = placing(r_nums[k]);

                teams[i, j].name = groups_text[i, j].text;

                teams[i, j].short_name = placing_short(r_nums[k]);

                GameObject.Find("Match " + letters[i] + sides_and_tours[0, j]).GetComponent<Text>().text = groups_text[i, j].text;
                GameObject.Find("Match " + letters[i] + sides_and_tours[1, j]).GetComponent<Text>().text = groups_text[i, j].text;
                GameObject.Find("Match " + letters[i] + sides_and_tours[2, j]).GetComponent<Text>().text = groups_text[i, j].text;
                GameObject.Find("Match " + letters[i] + sides_and_tours[3, j]).GetComponent<Text>().text = groups_text[i, j].text;

                teams[i, j].mat_f1 = placing_mat_f1(r_nums[k]);
                teams[i, j].mat_f2 = placing_mat_f2(r_nums[k]);
                teams[i, j].mat_gk = placing_mat_gk(r_nums[k]);
                teams[i, j].mat__f = placing_mat__f(r_nums[k]);

                k++;
            }
        }

        tracks_queue = new int[NUMBER_OF_TRACKS];
        for (int i = 0; i < NUMBER_OF_TRACKS; i++) { tracks_queue[i] = -1; }

        playlist = new AudioClip[NUMBER_OF_TRACKS];
        playlist_buffer = new AudioClip[NUMBER_OF_TRACKS] { track_1, track_2, track_3, track_4, track_5, track_6, track_7, track_8, track_9, track_10,
                     track_11, track_12, track_13, track_14, track_15, track_16, track_17, track_18, track_19, track_20, track_21, track_22 };

        audio = GetComponent<AudioSource>();
    }

    void FixedUpdate() //GetComponent<T>() довольно дорогостоящие и нужно стараться минимизировать их использование в своем проекте
    {
        //float margin = Random.Range(0.0f, 0.3f); //мб поможет с рандомом
        //camera.targetDisplay = 4;

        if (tr_timer > 0.9f)
        {
            if ((tr_timer % 1f >= 0.999f) || (tr_timer % 1f <= 0.001f))
            {
                tracks_queue[tr_counter] = foo_rand(tracks_queue, NUMBER_OF_TRACKS);
                print("трек " + tracks_queue[tr_counter]);
                playlist[tr_counter] = playlist_buffer[tracks_queue[tr_counter]];

                //заодно зарандомлю вторые места для плей оффа
                if (tr_counter < NUMBER_OF_GROUPS) { second_teams_random_array[tr_counter] = foo_rand(second_teams_random_array, NUMBER_OF_GROUPS, tr_counter); }

                tr_counter++;
            }
            tr_timer -= 0.02f;
        }
        else
        {
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                audio.Pause();
                if (pause_bool) { playlist_counter++; }
            }
            else if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                audio.Pause();
                if (playlist_counter == 0) { playlist_counter = NUMBER_OF_TRACKS - 2; }
                else { playlist_counter -= 2; }
                if (pause_bool) { playlist_counter++; }
            }
        }

        if ((!audio.isPlaying) && (!pause_bool))
        {
            playlist_counter++;
            audio.clip = playlist[playlist_counter % NUMBER_OF_TRACKS];// если не равно, то присвоение (мб поможет?)
            audio.Play();
            print("Track " + playlist_counter + " is playing");
        }

        if (Input.GetKeyUp(KeyCode.Return))
        {
            if (!pause_bool)
            {
                audio.Pause();
                pause_bool = true;
            }
            else
            {
                pause_bool = false;
                playlist_counter--;
            }
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            audio.volume += 0.0075f;
            print("Звук: " + audio.volume);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            audio.volume -= 0.0075f;
            print("Звук: " + audio.volume);
        }

        if ((tour <= 11) && (first_seeing_playoff))
        {
            if ((Input.GetKey(KeyCode.Alpha1)) || (Input.GetKey(KeyCode.Keypad4))) { camera_change(0); }
            else if ((Input.GetKey(KeyCode.Alpha2)) || (Input.GetKey(KeyCode.Keypad5))) { camera_change(1); }
            else if ((Input.GetKey(KeyCode.Alpha3)) || (Input.GetKey(KeyCode.Keypad6))) { camera_change(2); }
            else if ((Input.GetKey(KeyCode.Alpha4)) || (Input.GetKey(KeyCode.Keypad1))) { camera_change(3); }
            else if ((Input.GetKey(KeyCode.Alpha5)) || (Input.GetKey(KeyCode.Keypad2))) { camera_change(4); }
            else if ((Input.GetKey(KeyCode.Alpha6)) || (Input.GetKey(KeyCode.Keypad3))) { camera_change(5); }
            else if ((Input.GetKey(KeyCode.Alpha8)) || (Input.GetKey(KeyCode.Keypad8))) { camera_change(6); }
            else if (((Input.GetKey(KeyCode.Alpha7)) || (Input.GetKey(KeyCode.Keypad7))) && (current_cam != 228))
            {
                close_cams[current_cam].enabled = false;
                current_cam = 228;
                canvas_observer.enabled = true;
                for (int i = 0; i < 6; i++)
                {
                    obs_cams[i].enabled = true;
                }
            }
        }
        else if (tour <= 21)
        {
            if ((Input.GetKey(KeyCode.Alpha1)) || (Input.GetKey(KeyCode.Keypad1))) { camera_change(0); }
            else if (((Input.GetKey(KeyCode.Alpha2)) || (Input.GetKey(KeyCode.Keypad2))) && (!last_playoff_game)) { camera_change(1); }
            else if ((Input.GetKey(KeyCode.Alpha5)) || (Input.GetKey(KeyCode.Keypad4))) { camera_change(6); }
            else if ((Input.GetKey(KeyCode.Alpha4)) || (Input.GetKey(KeyCode.Keypad0))) { camera_change(7); }
            else if (((Input.GetKey(KeyCode.Alpha3)) || (Input.GetKey(KeyCode.Keypad3))) && (current_cam != 228) && (!last_playoff_game))
            {
                close_cams[current_cam].enabled = false;
                current_cam = 228;
                canvas_playoff_observer.enabled = true;
                for (int i = 0; i < 2; i++)
                {
                    obs_cams[i].enabled = true;
                }
            }
        }

        if ((Input.GetKey(KeyCode.Space)) && (!space))  //когда все скидывают, если сильня комбинация, то надо показать, чтобы думали, что тайтово играешь
        {
            if (tour <= 10)
            {
                space = true;

                k = 0;
                painting_arena_1(teams[k, left_num].short_name, teams[k, right_num].short_name, teams[k, left_num].mat__f,
                     teams[k, left_num].mat_f1, teams[k, left_num].mat_f2, teams[k, left_num].mat_gk, teams[k, right_num].mat_f1, teams[k, right_num].mat_f2, teams[k, right_num].mat_gk);
                k++;
                painting_arena_2(teams[k, left_num].short_name, teams[k, right_num].short_name, teams[k, left_num].mat__f,
                     teams[k, left_num].mat_f1, teams[k, left_num].mat_f2, teams[k, left_num].mat_gk, teams[k, right_num].mat_f1, teams[k, right_num].mat_f2, teams[k, right_num].mat_gk);
                k++;
                painting_arena_3(teams[k, left_num].short_name, teams[k, right_num].short_name, teams[k, left_num].mat__f,
                     teams[k, left_num].mat_f1, teams[k, left_num].mat_f2, teams[k, left_num].mat_gk, teams[k, right_num].mat_f1, teams[k, right_num].mat_f2, teams[k, right_num].mat_gk);
                k++;
                painting_arena_4(teams[k, left_num].short_name, teams[k, right_num].short_name, teams[k, left_num].mat__f,
                     teams[k, left_num].mat_f1, teams[k, left_num].mat_f2, teams[k, left_num].mat_gk, teams[k, right_num].mat_f1, teams[k, right_num].mat_f2, teams[k, right_num].mat_gk);
                k++;
                painting_arena_5(teams[k, left_num].short_name, teams[k, right_num].short_name, teams[k, left_num].mat__f,
                     teams[k, left_num].mat_f1, teams[k, left_num].mat_f2, teams[k, left_num].mat_gk, teams[k, right_num].mat_f1, teams[k, right_num].mat_f2, teams[k, right_num].mat_gk);
                k++;
                painting_arena_6(teams[k, left_num].short_name, teams[k, right_num].short_name, teams[k, left_num].mat__f,
                     teams[k, left_num].mat_f1, teams[k, left_num].mat_f2, teams[k, left_num].mat_gk, teams[k, right_num].mat_f1, teams[k, right_num].mat_f2, teams[k, right_num].mat_gk);

                score_a_l_buf = GameObject.Find("Match sc a_l (" + tour + ")").GetComponent<Text>();  //УБРАТЬ ОТСЮДА GET COMPONENT // хотя без этого буфферы бессмысленны
                score_b_l_buf = GameObject.Find("Match sc b_l (" + tour + ")").GetComponent<Text>();
                score_c_l_buf = GameObject.Find("Match sc c_l (" + tour + ")").GetComponent<Text>();
                score_d_l_buf = GameObject.Find("Match sc d_l (" + tour + ")").GetComponent<Text>();
                score_e_l_buf = GameObject.Find("Match sc e_l (" + tour + ")").GetComponent<Text>();
                score_f_l_buf = GameObject.Find("Match sc f_l (" + tour + ")").GetComponent<Text>();
                score_a_r_buf = GameObject.Find("Match sc a_r (" + tour + ")").GetComponent<Text>();
                score_b_r_buf = GameObject.Find("Match sc b_r (" + tour + ")").GetComponent<Text>();
                score_c_r_buf = GameObject.Find("Match sc c_r (" + tour + ")").GetComponent<Text>();
                score_d_r_buf = GameObject.Find("Match sc d_r (" + tour + ")").GetComponent<Text>();
                score_e_r_buf = GameObject.Find("Match sc e_r (" + tour + ")").GetComponent<Text>();
                score_f_r_buf = GameObject.Find("Match sc f_r (" + tour + ")").GetComponent<Text>();
                ot_a_buf = GameObject.Find("Match ot a (" + tour + ")").GetComponent<Text>();
                ot_b_buf = GameObject.Find("Match ot b (" + tour + ")").GetComponent<Text>();
                ot_c_buf = GameObject.Find("Match ot c (" + tour + ")").GetComponent<Text>();
                ot_d_buf = GameObject.Find("Match ot d (" + tour + ")").GetComponent<Text>();
                ot_e_buf = GameObject.Find("Match ot e (" + tour + ")").GetComponent<Text>();
                ot_f_buf = GameObject.Find("Match ot f (" + tour + ")").GetComponent<Text>();
                time_a_buf = GameObject.Find("Match st a (" + tour + ")").GetComponent<Text>();
                time_b_buf = GameObject.Find("Match st b (" + tour + ")").GetComponent<Text>();
                time_c_buf = GameObject.Find("Match st c (" + tour + ")").GetComponent<Text>();
                time_d_buf = GameObject.Find("Match st d (" + tour + ")").GetComponent<Text>();
                time_e_buf = GameObject.Find("Match st e (" + tour + ")").GetComponent<Text>();
                time_f_buf = GameObject.Find("Match st f (" + tour + ")").GetComponent<Text>();

                pk1_scr.standings_ce_score = score_a_l_buf;
                pk2_scr.standings_ce_score = score_b_l_buf;
                pk3_scr.standings_ce_score = score_c_l_buf;
                pk4_scr.standings_ce_score = score_d_l_buf;
                pk5_scr.standings_ce_score = score_e_l_buf;
                pk6_scr.standings_ce_score = score_f_l_buf;
                pk1_scr.standings_k_score = score_a_r_buf;
                pk2_scr.standings_k_score = score_b_r_buf;
                pk3_scr.standings_k_score = score_c_r_buf;
                pk4_scr.standings_k_score = score_d_r_buf;
                pk5_scr.standings_k_score = score_e_r_buf;
                pk6_scr.standings_k_score = score_f_r_buf;

                pk1_scr.standings_ot_text = ot_a_buf;
                pk2_scr.standings_ot_text = ot_b_buf;
                pk3_scr.standings_ot_text = ot_c_buf;
                pk4_scr.standings_ot_text = ot_d_buf;
                pk5_scr.standings_ot_text = ot_e_buf;
                pk6_scr.standings_ot_text = ot_f_buf;

                pk1_scr.standings_time_text = time_a_buf;
                pk2_scr.standings_time_text = time_b_buf;
                pk3_scr.standings_time_text = time_c_buf;
                pk4_scr.standings_time_text = time_d_buf;
                pk5_scr.standings_time_text = time_e_buf;
                pk6_scr.standings_time_text = time_f_buf;

                if (tour == 1) //на всякий случай включаем скрипты пака и игроков, если перед игрой они были выключены
                {
                    pk1_scr.enabled = true;
                    pk2_scr.enabled = true;
                    pk3_scr.enabled = true;
                    pk4_scr.enabled = true;
                    pk5_scr.enabled = true;
                    pk6_scr.enabled = true;
                    ar1_lf1_ai.enabled = true;
                    ar1_lgk_ai.enabled = true;
                    ar1_rf1_ai.enabled = true;
                    ar1_rgk_ai.enabled = true;
                    ar2_lf1_ai.enabled = true;
                    ar2_lgk_ai.enabled = true;
                    ar2_rf1_ai.enabled = true;
                    ar2_rgk_ai.enabled = true;
                    ar3_lf1_ai.enabled = true;
                    ar3_lgk_ai.enabled = true;
                    ar3_rf1_ai.enabled = true;
                    ar3_rgk_ai.enabled = true;
                    ar4_lf1_ai.enabled = true;
                    ar4_lgk_ai.enabled = true;
                    ar4_rf1_ai.enabled = true;
                    ar4_rgk_ai.enabled = true;
                    ar5_lf1_ai.enabled = true;
                    ar5_lgk_ai.enabled = true;
                    ar5_rf1_ai.enabled = true;
                    ar5_rgk_ai.enabled = true;
                    ar6_lf1_ai.enabled = true;
                    ar6_lgk_ai.enabled = true;
                    ar6_rf1_ai.enabled = true;
                    ar6_rgk_ai.enabled = true;
                    if (forwards == 2)
                    {
                        ar1_lf2_ai.enabled = true;
                        ar1_rf2_ai.enabled = true;
                        ar2_lf2_ai.enabled = true;
                        ar2_rf2_ai.enabled = true;
                        ar3_lf2_ai.enabled = true;
                        ar3_rf2_ai.enabled = true;
                        ar4_lf2_ai.enabled = true;
                        ar4_rf2_ai.enabled = true;
                        ar5_lf2_ai.enabled = true;
                        ar5_rf2_ai.enabled = true;
                        ar6_lf2_ai.enabled = true;
                        ar6_rf2_ai.enabled = true;
                    }
                }
                else
                {
                    pk1_scr.need_new_game = true;
                    pk2_scr.need_new_game = true;
                    pk3_scr.need_new_game = true;
                    pk4_scr.need_new_game = true;
                    pk5_scr.need_new_game = true;
                    pk6_scr.need_new_game = true;
                }
            }
            if ((tour >= 11) && (tour <= 19))
            {
                if (first_seeing_playoff) //должно выполнится один раз
                {
                    //pk1_scr.playoff = true; // для отладки
                    //pk2_scr.playoff = true;

                    space = true;

                    camera_change(7);

                    first_seeing_playoff = false;

                    pk1_scr.score_text3.text = ""; // затираем счёт для красоты
                    pk2_scr.score_text3.text = "";

                    obs_cams[0].rect = new Rect(0.0f, 0.0f, 0.5f, 0.9f);
                    obs_cams[1].rect = new Rect(0.5f, 0.0f, 0.5f, 0.9f);

                    pk1_scr.score_text2 = GameObject.Find("score_text (1)").GetComponent<Text>();
                    pk1_scr.time_text2 = GameObject.Find("time_text (1)").GetComponent<Text>();
                    pk1_scr.ce_team_text2 = GameObject.Find("ce_team_text (1)").GetComponent<Text>();
                    pk1_scr.k_team_text2 = GameObject.Find("k_team_text (1)").GetComponent<Text>();
                    pk1_scr.time_number_text2 = GameObject.Find("time_number_text (1)").GetComponent<Text>();

                    pk2_scr.score_text2 = GameObject.Find("score_text (2)").GetComponent<Text>();
                    pk2_scr.time_text2 = GameObject.Find("time_text (2)").GetComponent<Text>();
                    pk2_scr.ce_team_text2 = GameObject.Find("ce_team_text (2)").GetComponent<Text>();
                    pk2_scr.k_team_text2 = GameObject.Find("k_team_text (2)").GetComponent<Text>();
                    pk2_scr.time_number_text2 = GameObject.Find("time_number_text (2)").GetComponent<Text>();

                    //выключаем ненужные скрипты для производительности
                    pk3_scr.enabled = false;
                    pk4_scr.enabled = false;
                    pk5_scr.enabled = false;
                    pk6_scr.enabled = false;
                    ar3_lf1_ai.enabled = false;
                    ar3_lgk_ai.enabled = false;
                    ar3_rf1_ai.enabled = false;
                    ar3_rgk_ai.enabled = false;
                    ar4_lf1_ai.enabled = false;
                    ar4_lgk_ai.enabled = false;
                    ar4_rf1_ai.enabled = false;
                    ar4_rgk_ai.enabled = false;
                    ar5_lf1_ai.enabled = false;
                    ar5_lgk_ai.enabled = false;
                    ar5_rf1_ai.enabled = false;
                    ar5_rgk_ai.enabled = false;
                    ar6_lf1_ai.enabled = false;
                    ar6_lgk_ai.enabled = false;
                    ar6_rf1_ai.enabled = false;
                    ar6_rgk_ai.enabled = false;
                    if (forwards == 2)
                    {
                        ar3_lf2_ai.enabled = false;
                        ar3_rf2_ai.enabled = false;
                        ar4_lf2_ai.enabled = false;
                        ar4_rf2_ai.enabled = false;
                        ar5_lf2_ai.enabled = false;
                        ar5_rf2_ai.enabled = false;
                        ar6_lf2_ai.enabled = false;
                        ar6_rf2_ai.enabled = false;
                    }

                    playoff_teams = new Team[NUMBER_OF_GROUPS, 2] { { teams_sort[0, 0], teams_sort[second_teams_random_array[0], 1] },
                                                                    { teams_sort[1, 0], teams_sort[second_teams_random_array[1], 1] },
                                                                    { teams_sort[2, 0], teams_sort[second_teams_random_array[2], 1] },
                                                                    { teams_sort[3, 0], teams_sort[second_teams_random_array[3], 1] },
                                                                    { teams_sort[4, 0], teams_sort[second_teams_random_array[4], 1] },
                                                                    { teams_sort[5, 0], teams_sort[second_teams_random_array[5], 1] } };

                    for (int i = 0; i < NUMBER_OF_GROUPS; i++)
                    {
                        playoff_pairs_text[i].team_texts[0].text = playoff_teams[i, 0].name;
                        playoff_pairs_text[i].team_texts[1].text = playoff_teams[i, 1].name;
                    }
                }
                else
                {
                    space = true;

                    if ((tour == 11) || (tour == 14)) { playoff_pair_nums[0] = 0; playoff_pair_nums[1] = 1; }
                    else if ((tour == 12) || (tour == 15)) { playoff_pair_nums[0] = 2; playoff_pair_nums[1] = 3; }
                    else if ((tour == 13) || (tour == 16)) { playoff_pair_nums[0] = 4; playoff_pair_nums[1] = 5; }
                    else
                    {
                        k = 0;
                        for (int i = 0; i < 6; i++)
                        {
                            if (playoff_pairs_text[i].general_score_texts[0].text == playoff_pairs_text[i].general_score_texts[1].text)
                            {
                                playoff_pair_nums[k] = i;
                                k++;
                                if (k == 2) { break; }
                            }
                        }
                        if (k == 1)
                        {
                            last_playoff_game = true;
                        }
                        else if (k == 0)
                        {
                            tour = 20; //конец плей оффа
                        }
                    }

                    if (tour <= 19)
                    {
                        if ((tour >= 14) && (tour <= 16)) { playoff_pair_match_num = 1; }
                        else if (tour >= 17) { playoff_pair_match_num = 2; }

                        if (playoff_pair_match_num != 1)
                        {
                            pk1_scr.text3_reverse = false;
                            pk2_scr.text3_reverse = false;
                            host = 0; guest = 1;
                        }
                        else
                        {
                            pk1_scr.text3_reverse = true;
                            pk2_scr.text3_reverse = true;
                            host = 1; guest = 0;
                        }

                        k = 0;
                        painting_arena_1(playoff_teams[playoff_pair_nums[k], host].short_name, playoff_teams[playoff_pair_nums[k], guest].short_name, playoff_teams[playoff_pair_nums[k], host].mat__f,
                             playoff_teams[playoff_pair_nums[k], host].mat_f1, playoff_teams[playoff_pair_nums[k], host].mat_f2, playoff_teams[playoff_pair_nums[k], host].mat_gk,
                             playoff_teams[playoff_pair_nums[k], guest].mat_f1, playoff_teams[playoff_pair_nums[k], guest].mat_f2, playoff_teams[playoff_pair_nums[k], guest].mat_gk);

                        once_a = false;
                        pk1_scr.score_text3 = playoff_pairs_text[playoff_pair_nums[0]].match_score_texts[playoff_pair_match_num];
                        pk1_scr.standings_time_text = playoff_pairs_text[playoff_pair_nums[0]].match_time_texts[playoff_pair_match_num];
                        pk1_scr.need_new_game = true;
                        pk1_scr.ce_win = false;
                        pk1_scr.k_win = false;

                        if (!last_playoff_game)
                        {
                            k = 1;
                            painting_arena_2(playoff_teams[playoff_pair_nums[k], host].short_name, playoff_teams[playoff_pair_nums[k], guest].short_name, playoff_teams[playoff_pair_nums[k], host].mat__f,
                                 playoff_teams[playoff_pair_nums[k], host].mat_f1, playoff_teams[playoff_pair_nums[k], host].mat_f2, playoff_teams[playoff_pair_nums[k], host].mat_gk,
                                 playoff_teams[playoff_pair_nums[k], guest].mat_f1, playoff_teams[playoff_pair_nums[k], guest].mat_f2, playoff_teams[playoff_pair_nums[k], guest].mat_gk);

                            once_b = false;
                            pk2_scr.score_text3 = playoff_pairs_text[playoff_pair_nums[1]].match_score_texts[playoff_pair_match_num];
                            pk2_scr.standings_time_text = playoff_pairs_text[playoff_pair_nums[1]].match_time_texts[playoff_pair_match_num];
                            pk2_scr.need_new_game = true;
                            pk2_scr.ce_win = false;
                            pk2_scr.k_win = false;
                        }

                        tour++;//устанавливается будующий тур
                    }
                }
            }
        }

        if ((!first_seeing_playoff) && (fsp_timer > 0f)) //потестить и сделать так чтоб нажималось один раз
        {
            fsp_timer -= 0.02f;
            if (fsp_timer <= 0f)
            {
                space = false;
            }
        }

        if ((tour >= 12) && (tour <= 20) && (!first_seeing_playoff))
        {
            if ((pk1_scr.ce_win == true) && (!once_a))
            {
                if (playoff_pair_match_num != 1)
                {
                    playoff_pairs_text[playoff_pair_nums[0]].general_score_texts[0].text = (Convert.ToInt32(playoff_pairs_text[playoff_pair_nums[0]].general_score_texts[0].text) + 1).ToString();
                }
                else
                {
                    playoff_pairs_text[playoff_pair_nums[0]].general_score_texts[1].text = (Convert.ToInt32(playoff_pairs_text[playoff_pair_nums[0]].general_score_texts[1].text) + 1).ToString();
                }
                once_a = true;
            }
            else if ((pk1_scr.k_win == true) && (!once_a))
            {
                if (playoff_pair_match_num != 1)
                {
                    playoff_pairs_text[playoff_pair_nums[0]].general_score_texts[1].text = (Convert.ToInt32(playoff_pairs_text[playoff_pair_nums[0]].general_score_texts[1].text) + 1).ToString();
                }
                else
                {
                    playoff_pairs_text[playoff_pair_nums[0]].general_score_texts[0].text = (Convert.ToInt32(playoff_pairs_text[playoff_pair_nums[0]].general_score_texts[0].text) + 1).ToString();
                }
                once_a = true;
            }

            if (!last_playoff_game)
            {
                if ((pk2_scr.ce_win == true) && (!once_b))
                {
                    if (playoff_pair_match_num != 1)
                    {
                        playoff_pairs_text[playoff_pair_nums[1]].general_score_texts[0].text = (Convert.ToInt32(playoff_pairs_text[playoff_pair_nums[1]].general_score_texts[0].text) + 1).ToString();
                    }
                    else
                    {
                        playoff_pairs_text[playoff_pair_nums[1]].general_score_texts[1].text = (Convert.ToInt32(playoff_pairs_text[playoff_pair_nums[1]].general_score_texts[1].text) + 1).ToString();
                    }
                    once_b = true;
                }
                else if ((pk2_scr.k_win == true) && (!once_b))
                {
                    if (playoff_pair_match_num != 1)
                    {
                        playoff_pairs_text[playoff_pair_nums[1]].general_score_texts[1].text = (Convert.ToInt32(playoff_pairs_text[playoff_pair_nums[1]].general_score_texts[1].text) + 1).ToString();
                    }
                    else
                    {
                        playoff_pairs_text[playoff_pair_nums[1]].general_score_texts[0].text = (Convert.ToInt32(playoff_pairs_text[playoff_pair_nums[1]].general_score_texts[0].text) + 1).ToString();
                    }
                    once_b = true;
                }

                if (once_a && once_b)
                {
                    space = false;
                    if (tour == 20) { tour = 21; }
                }
            }
            else if (once_a)
            {
                space = false;
                tour = 21;
            }
        }

        if ((space) && (tour <= 10))
        {
            if ((time_a_buf.text == "Finished") && (!once_a))
            {
                k = 0;
                igrovoy_komputer(teams[k, left_num], teams[k, right_num], score_a_l_buf, score_a_r_buf, ot_a_buf, k);
                once_a = true;
            }
            if ((time_b_buf.text == "Finished") && (!once_b))
            {
                k = 1;
                igrovoy_komputer(teams[k, left_num], teams[k, right_num], score_b_l_buf, score_b_r_buf, ot_b_buf, k);
                once_b = true;
            }
            if ((time_c_buf.text == "Finished") && (!once_c))
            {
                k = 2;
                igrovoy_komputer(teams[k, left_num], teams[k, right_num], score_c_l_buf, score_c_r_buf, ot_c_buf, k);
                once_c = true;
            }
            if ((time_d_buf.text == "Finished") && (!once_d))
            {
                k = 3;
                igrovoy_komputer(teams[k, left_num], teams[k, right_num], score_d_l_buf, score_d_r_buf, ot_d_buf, k);
                once_d = true;
            }
            if ((time_e_buf.text == "Finished") && (!once_e))
            {
                k = 4;
                igrovoy_komputer(teams[k, left_num], teams[k, right_num], score_e_l_buf, score_e_r_buf, ot_e_buf, k);
                once_e = true;
            }
            if ((time_f_buf.text == "Finished") && (!once_f))
            {
                k = 5;
                igrovoy_komputer(teams[k, left_num], teams[k, right_num], score_f_l_buf, score_f_r_buf, ot_f_buf, k);
                once_f = true;
            }

            if ((time_a_buf.text == "Finished") && (time_b_buf.text == "Finished") && (time_c_buf.text == "Finished") &&
                (time_d_buf.text == "Finished") && (time_e_buf.text == "Finished") && (time_f_buf.text == "Finished"))
            {
                tour++;
                once_a = false;
                once_b = false;
                once_c = false;
                once_d = false;
                once_e = false;
                once_f = false;
                space = false;

                if (tour == 2) { left_num = 3; right_num = 4; }
                else if (tour == 3) { left_num = 5; right_num = 1; }
                else if (tour == 4) { left_num = 2; right_num = 3; }
                else if (tour == 5) { left_num = 4; right_num = 5; }
                else if (tour == 6) { left_num = 1; right_num = 3; }
                else if (tour == 7) { left_num = 2; right_num = 4; }
                else if (tour == 8) { left_num = 3; right_num = 5; }
                else if (tour == 9) { left_num = 4; right_num = 1; }
                else if (tour == 10) { left_num = 5; right_num = 2; }
                left_num--;
                right_num--;
            }
        }
    }

    int foo_rand(int[] arr, int size) // 2 3 4 1 5 // происхлдит свап единицы с пятёркой
    {
        bool vacant;
        System.Random rand = new System.Random();
        int r = rand.Next(size);
        for (int i = 0; i < size; i++)
        {
            vacant = true;
            for (int j = 0; j < size; j++)
            {
                if (arr[j] == (r + i) % size)
                {
                    vacant = false;
                    break;
                }
            }
            if (vacant)
            {
                if (size == NUMBER_OF_TEAMS) { print((r + i) % size); }//эта строчка только для отладки
                return (r + i) % size;
            }
        }
        print("Fatal Error");
        return -1;
    }

    int foo_rand(int[] arr, int size, int place)
    {
        bool vacant;
        System.Random rand = new System.Random();
        int r = rand.Next(size);
        for (int i = 0; i < size; i++)
        {
            if ((r + i) % size == place) { continue; }
            vacant = true;
            for (int j = 0; j < size; j++)
            {
                if (arr[j] == (r + i) % size)
                {
                    vacant = false;
                    break;
                }
            }
            if (vacant)
            {
                if (size == NUMBER_OF_TEAMS) { print((r + i) % size); }//эта строчка только для отладки
                return (r + i) % size;
            }
        }

        print("Исключительная ситуация, справился?");
        //если ошибка, например сюда 1 2 _ 4 5 хотим поставить тройку // тогда свапаем с двойкой
        int previous_place;
        if (place == 0) { previous_place = size - 1; }
        else { previous_place = place - 1; }
        int buf = arr[previous_place];
        arr[previous_place] = place;
        return buf;
    }

    string placing(int rn)
    {
        if (rn == 1) { return team_1_long; }
        if (rn == 2) { return team_2_long; }
        if (rn == 3) { return team_3_long; }
        if (rn == 4) { return team_4_long; }
        if (rn == 5) { return team_5_long; }
        if (rn == 6) { return team_6_long; }
        if (rn == 7) { return team_7_long; }
        if (rn == 8) { return team_8_long; }
        if (rn == 9) { return team_9_long; }
        if (rn == 10) { return team_10_long; }
        if (rn == 11) { return team_11_long; }
        if (rn == 12) { return team_12_long; }
        if (rn == 13) { return team_13_long; }
        if (rn == 14) { return team_14_long; }
        if (rn == 15) { return team_15_long; }
        if (rn == 16) { return team_16_long; }
        if (rn == 17) { return team_17_long; }
        if (rn == 18) { return team_18_long; }
        if (rn == 19) { return team_19_long; }
        if (rn == 20) { return team_20_long; }
        if (rn == 21) { return team_21_long; }
        if (rn == 22) { return team_22_long; }
        if (rn == 23) { return team_23_long; }
        if (rn == 24) { return team_24_long; }
        if (rn == 25) { return team_25_long; }
        if (rn == 26) { return team_26_long; }
        if (rn == 27) { return team_27_long; }
        if (rn == 28) { return team_28_long; }
        if (rn == 29) { return team_29_long; }
        return team_30_long;
    }

    string placing_short(int rn)
    {
        if (rn == 1) { return team_1_short; }
        if (rn == 2) { return team_2_short; }
        if (rn == 3) { return team_3_short; }
        if (rn == 4) { return team_4_short; }
        if (rn == 5) { return team_5_short; }
        if (rn == 6) { return team_6_short; }
        if (rn == 7) { return team_7_short; }
        if (rn == 8) { return team_8_short; }
        if (rn == 9) { return team_9_short; }
        if (rn == 10) { return team_10_short; }
        if (rn == 11) { return team_11_short; }
        if (rn == 12) { return team_12_short; }
        if (rn == 13) { return team_13_short; }
        if (rn == 14) { return team_14_short; }
        if (rn == 15) { return team_15_short; }
        if (rn == 16) { return team_16_short; }
        if (rn == 17) { return team_17_short; }
        if (rn == 18) { return team_18_short; }
        if (rn == 19) { return team_19_short; }
        if (rn == 20) { return team_20_short; }
        if (rn == 21) { return team_21_short; }
        if (rn == 22) { return team_22_short; }
        if (rn == 23) { return team_23_short; }
        if (rn == 24) { return team_24_short; }
        if (rn == 25) { return team_25_short; }
        if (rn == 26) { return team_26_short; }
        if (rn == 27) { return team_27_short; }
        if (rn == 28) { return team_28_short; }
        if (rn == 29) { return team_29_short; }
        return team_30_short;
    }

    Material placing_mat_f1(int rn)
    {
        for (int i = 1; i < 30; i++)
        {
            if (rn == i) { return Resources.Load("t" + i + "f1") as Material; }
        }
        return Resources.Load("t30f1") as Material;
    }

    Material placing_mat_f2(int rn)
    {
        for (int i = 1; i < 30; i++)
        {
            if (rn == i) { return Resources.Load("t" + i + "f2") as Material; }
        }
        return Resources.Load("t30f2") as Material;
    }

    Material placing_mat_gk(int rn)
    {
        for (int i = 1; i < 30; i++)
        {
            if (rn == i) { return Resources.Load("t" + i + "gk") as Material; }
        }
        return Resources.Load("t30gk") as Material;
    }

    Material placing_mat__f(int rn)
    {
        for (int i = 1; i < 30; i++)
        {
            if (rn == i) { return Resources.Load("t" + i + "_fl") as Material; }
        }
        return Resources.Load("t30_fl") as Material;
    }

    void painting_arena_1(string left_team, string right_team, Material floor,
                          Material left_f1, Material left_f2, Material left_gk, Material right_f1, Material right_f2, Material right_gk)
    {
        pk1_scr.ce_team = left_team;//устанавливается шорт название левой тимы
        pk1_scr.k_team = right_team;//устанавливается шорт название правой тимы
        ar1__fl.GetComponent<Renderer>().material = floor;//красится пол
        ar1_lf1.GetComponent<Renderer>().material = left_f1;//красятся левые игроки
        ar1_lf2.GetComponent<Renderer>().material = left_f2;
        ar1_lgk.GetComponent<Renderer>().material = left_gk;
        ar1_rf1.GetComponent<Renderer>().material = right_f1;//красятся правые игроки
        ar1_rf2.GetComponent<Renderer>().material = right_f2;
        ar1_rgk.GetComponent<Renderer>().material = right_gk;
    }
    void painting_arena_2(string left_team, string right_team, Material floor,
                          Material left_f1, Material left_f2, Material left_gk, Material right_f1, Material right_f2, Material right_gk)
    {
        pk2_scr.ce_team = left_team;
        pk2_scr.k_team = right_team;
        ar2__fl.GetComponent<Renderer>().material = floor;
        ar2_lf1.GetComponent<Renderer>().material = left_f1;
        ar2_lf2.GetComponent<Renderer>().material = left_f2;
        ar2_lgk.GetComponent<Renderer>().material = left_gk;
        ar2_rf1.GetComponent<Renderer>().material = right_f1;
        ar2_rf2.GetComponent<Renderer>().material = right_f2;
        ar2_rgk.GetComponent<Renderer>().material = right_gk;
    }
    void painting_arena_3(string left_team, string right_team, Material floor,
                          Material left_f1, Material left_f2, Material left_gk, Material right_f1, Material right_f2, Material right_gk)
    {
        pk3_scr.ce_team = left_team;
        pk3_scr.k_team = right_team;
        ar3__fl.GetComponent<Renderer>().material = floor;
        ar3_lf1.GetComponent<Renderer>().material = left_f1;
        ar3_lf2.GetComponent<Renderer>().material = left_f2;
        ar3_lgk.GetComponent<Renderer>().material = left_gk;
        ar3_rf1.GetComponent<Renderer>().material = right_f1;
        ar3_rf2.GetComponent<Renderer>().material = right_f2;
        ar3_rgk.GetComponent<Renderer>().material = right_gk;
    }
    void painting_arena_4(string left_team, string right_team, Material floor,
                          Material left_f1, Material left_f2, Material left_gk, Material right_f1, Material right_f2, Material right_gk)
    {
        pk4_scr.ce_team = left_team;
        pk4_scr.k_team = right_team;
        ar4__fl.GetComponent<Renderer>().material = floor;
        ar4_lf1.GetComponent<Renderer>().material = left_f1;
        ar4_lf2.GetComponent<Renderer>().material = left_f2;
        ar4_lgk.GetComponent<Renderer>().material = left_gk;
        ar4_rf1.GetComponent<Renderer>().material = right_f1;
        ar4_rf2.GetComponent<Renderer>().material = right_f2;
        ar4_rgk.GetComponent<Renderer>().material = right_gk;
    }
    void painting_arena_5(string left_team, string right_team, Material floor,
                          Material left_f1, Material left_f2, Material left_gk, Material right_f1, Material right_f2, Material right_gk)
    {
        pk5_scr.ce_team = left_team;
        pk5_scr.k_team = right_team;
        ar5__fl.GetComponent<Renderer>().material = floor;
        ar5_lf1.GetComponent<Renderer>().material = left_f1;
        ar5_lf2.GetComponent<Renderer>().material = left_f2;
        ar5_lgk.GetComponent<Renderer>().material = left_gk;
        ar5_rf1.GetComponent<Renderer>().material = right_f1;
        ar5_rf2.GetComponent<Renderer>().material = right_f2;
        ar5_rgk.GetComponent<Renderer>().material = right_gk;
    }
    void painting_arena_6(string left_team, string right_team, Material floor,
                          Material left_f1, Material left_f2, Material left_gk, Material right_f1, Material right_f2, Material right_gk)
    {
        pk6_scr.ce_team = left_team;
        pk6_scr.k_team = right_team;
        ar6__fl.GetComponent<Renderer>().material = floor;
        ar6_lf1.GetComponent<Renderer>().material = left_f1;
        ar6_lf2.GetComponent<Renderer>().material = left_f2;
        ar6_lgk.GetComponent<Renderer>().material = left_gk;
        ar6_rf1.GetComponent<Renderer>().material = right_f1;
        ar6_rf2.GetComponent<Renderer>().material = right_f2;
        ar6_rgk.GetComponent<Renderer>().material = right_gk;
    }

    int add_points(int points, Text our_score_text, Text enemy_score_text, Text overtime_text)
    {
        if ((Convert.ToInt32(our_score_text.text) > Convert.ToInt32(enemy_score_text.text)) && (overtime_text.text != "OT")) { points += 3; }
        else if ((Convert.ToInt32(our_score_text.text) > Convert.ToInt32(enemy_score_text.text)) && (overtime_text.text == "OT")) { points += 2; }
        else if ((Convert.ToInt32(our_score_text.text) < Convert.ToInt32(enemy_score_text.text)) && (overtime_text.text == "OT")) { points++; }
        return points;
    }

    void overtaking(int letter_num)
    {
        Team buf;
        for (int i = 0; i < 5; i++)
        {
            for (int j = i + 1; j < 5; j++)
            {
                if (teams_sort[letter_num, i].points < teams_sort[letter_num, j].points)
                {
                    buf = teams_sort[letter_num, j];
                    teams_sort[letter_num, j] = teams_sort[letter_num, i];
                    teams_sort[letter_num, i] = buf;
                }
                else if (teams_sort[letter_num, i].points == teams_sort[letter_num, j].points)
                {
                    if (teams_sort[letter_num, i].matches > teams_sort[letter_num, j].matches)
                    {
                        buf = teams_sort[letter_num, j];
                        teams_sort[letter_num, j] = teams_sort[letter_num, i];
                        teams_sort[letter_num, i] = buf;
                    }
                    else if (teams_sort[letter_num, i].matches == teams_sort[letter_num, j].matches)
                    {
                        bool i_win = false;
                        for (int k = 0; k < 4; k++)
                        {
                            if (teams_sort[letter_num, i].vanquished[k] == teams_sort[letter_num, j].number)
                            {
                                i_win = true;
                                break;
                            }
                        }

                        // возможно стоит сдесь написать private_battles

                        if (!i_win)
                        {
                            bool j_win = false;
                            for (int k = 0; k < 4; k++)
                            {
                                if (teams_sort[letter_num, j].vanquished[k] == teams_sort[letter_num, i].number)
                                {
                                    j_win = true;
                                    break;
                                }
                            }

                            if (j_win)
                            {
                                buf = teams_sort[letter_num, j];
                                teams_sort[letter_num, j] = teams_sort[letter_num, i];
                                teams_sort[letter_num, i] = buf;
                            }
                            else
                            {
                                if (teams_sort[letter_num, i].difference < teams_sort[letter_num, j].difference)
                                {
                                    buf = teams_sort[letter_num, j];
                                    teams_sort[letter_num, j] = teams_sort[letter_num, i];
                                    teams_sort[letter_num, i] = buf;
                                }
                                else if (teams_sort[letter_num, i].difference == teams_sort[letter_num, j].difference)
                                {
                                    if (teams_sort[letter_num, i].goals < teams_sort[letter_num, j].goals)
                                    {
                                        buf = teams_sort[letter_num, j];
                                        teams_sort[letter_num, j] = teams_sort[letter_num, i];
                                        teams_sort[letter_num, i] = buf;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        bool figure_appeared = false;

        if ((teams_sort[letter_num, 0].points == teams_sort[letter_num, 1].points) &&
            (teams_sort[letter_num, 1].points == teams_sort[letter_num, 2].points) &&
            (teams_sort[letter_num, 2].points == teams_sort[letter_num, 3].points) &&
            (teams_sort[letter_num, 3].points == teams_sort[letter_num, 4].points) &&
            (teams_sort[letter_num, 0].matches == teams_sort[letter_num, 1].matches) &&
            (teams_sort[letter_num, 1].matches == teams_sort[letter_num, 2].matches) &&
            (teams_sort[letter_num, 2].matches == teams_sort[letter_num, 3].matches) &&
            (teams_sort[letter_num, 3].matches == teams_sort[letter_num, 4].matches) &&
            (private_battles(letter_num, 0, 1) != 0) && (private_battles(letter_num, 0, 2) != 0) &&
            (private_battles(letter_num, 0, 3) != 0) && (private_battles(letter_num, 0, 4) != 0) &&
            (private_battles(letter_num, 1, 2) != 0) && (private_battles(letter_num, 1, 3) != 0) &&
            (private_battles(letter_num, 1, 4) != 0) && (private_battles(letter_num, 2, 3) != 0) &&
            (private_battles(letter_num, 2, 4) != 0) && (private_battles(letter_num, 3, 4) != 0))
        {
            figure_appeared = true;
            triangle(letter_num, 0, 5);
        }

        if (!figure_appeared)
        {
            for (int i = 0; i < 2; i++)
            {
                if ((teams_sort[letter_num, i + 0].points == teams_sort[letter_num, i + 1].points) &&
                    (teams_sort[letter_num, i + 1].points == teams_sort[letter_num, i + 2].points) &&
                    (teams_sort[letter_num, i + 2].points == teams_sort[letter_num, i + 3].points) &&
                    (teams_sort[letter_num, i + 0].matches == teams_sort[letter_num, i + 1].matches) &&
                    (teams_sort[letter_num, i + 1].matches == teams_sort[letter_num, i + 2].matches) &&
                    (teams_sort[letter_num, i + 2].matches == teams_sort[letter_num, i + 3].matches) &&
                    (private_battles(letter_num, i + 0, i + 1) != 0) && (private_battles(letter_num, i + 0, i + 2) != 0) &&
                    (private_battles(letter_num, i + 0, i + 3) != 0) && (private_battles(letter_num, i + 1, i + 2) != 0) &&
                    (private_battles(letter_num, i + 1, i + 3) != 0) && (private_battles(letter_num, i + 2, i + 3) != 0))
                {
                    figure_appeared = true;

                    if ((private_battles(letter_num, i + 0, i + 1) == 1) && (private_battles(letter_num, i + 0, i + 2) == 1) &&
                        (private_battles(letter_num, i + 0, i + 3) == 1))
                    {
                        triangle(letter_num, i + 1, 3);
                        break;
                    }
                    if ((private_battles(letter_num, i + 1, i + 0) == 1) && (private_battles(letter_num, i + 1, i + 2) == 1) &&
                        (private_battles(letter_num, i + 1, i + 3) == 1))
                    {
                        swap(letter_num, i + 1, i + 0);
                        triangle(letter_num, i + 1, 3);
                        break;
                    }
                    if ((private_battles(letter_num, i + 2, i + 0) == 1) && (private_battles(letter_num, i + 2, i + 1) == 1) &&
                        (private_battles(letter_num, i + 2, i + 3) == 1))
                    {
                        swap(letter_num, i + 2, i + 1);
                        swap(letter_num, i + 1, i + 0);
                        triangle(letter_num, i + 1, 3);
                        break;
                    }
                    if ((private_battles(letter_num, i + 3, i + 0) == 1) && (private_battles(letter_num, i + 3, i + 1) == 1) &&
                        (private_battles(letter_num, i + 3, i + 2) == 1))
                    {
                        swap(letter_num, i + 3, i + 2);
                        swap(letter_num, i + 2, i + 1);
                        swap(letter_num, i + 1, i + 0);
                        triangle(letter_num, i + 1, 3);
                        break;
                    }

                    if ((private_battles(letter_num, i + 0, i + 1) == 2) && (private_battles(letter_num, i + 0, i + 2) == 2) &&
                        (private_battles(letter_num, i + 0, i + 3) == 2))
                    {
                        swap(letter_num, i + 0, i + 1);
                        swap(letter_num, i + 1, i + 2);
                        swap(letter_num, i + 2, i + 3);
                        triangle(letter_num, i + 0, 3);
                        break;
                    }
                    if ((private_battles(letter_num, i + 1, i + 0) == 2) && (private_battles(letter_num, i + 1, i + 2) == 2) &&
                        (private_battles(letter_num, i + 1, i + 3) == 2))
                    {
                        swap(letter_num, i + 1, i + 2);
                        swap(letter_num, i + 2, i + 3);
                        triangle(letter_num, i + 0, 3);
                        break;
                    }
                    if ((private_battles(letter_num, i + 2, i + 0) == 2) && (private_battles(letter_num, i + 2, i + 1) == 2) &&
                        (private_battles(letter_num, i + 2, i + 3) == 2))
                    {
                        swap(letter_num, i + 2, i + 3);
                        triangle(letter_num, i + 0, 3);
                        break;
                    }
                    if ((private_battles(letter_num, i + 3, i + 0) == 2) && (private_battles(letter_num, i + 3, i + 1) == 2) &&
                        (private_battles(letter_num, i + 3, i + 2) == 2))
                    {
                        triangle(letter_num, i + 0, 3);
                        break;
                    }

                    triangle(letter_num, i + 0, 4);
                }
            }
        }

        if (!figure_appeared)
        {
            for (int i = 0; i < 3; i++)
            {
                if ((teams_sort[letter_num, i + 0].points == teams_sort[letter_num, i + 1].points) &&
                    (teams_sort[letter_num, i + 1].points == teams_sort[letter_num, i + 2].points) &&
                    (teams_sort[letter_num, i + 0].matches == teams_sort[letter_num, i + 1].matches) &&
                    (teams_sort[letter_num, i + 1].matches == teams_sort[letter_num, i + 2].matches))
                {
                    triangle(letter_num, i, 3);
                    break;
                }
            }
        }

        //щас записываем в таблицу

        for (int i = 0; i < 5; i++)
        {
            groups_text[letter_num, i].text = teams_sort[letter_num, i].name;
            points_text[letter_num, i].text = teams_sort[letter_num, i].points.ToString();
            matches_text[letter_num, i].text = teams_sort[letter_num, i].matches.ToString();
            differences_text[letter_num, i].text = teams_sort[letter_num, i].difference.ToString();
            goals_text[letter_num, i].text = teams_sort[letter_num, i].goals.ToString();
        }
    }

    void igrovoy_komputer(Team left_team, Team right_team, Text score_x_l_buf, Text score_x_r_buf, Text ot_x_buf, int letter_num)
    {
        int old_left_team_points = left_team.points;
        left_team.points = add_points(left_team.points, score_x_l_buf, score_x_r_buf, ot_x_buf);
        right_team.points = add_points(right_team.points, score_x_r_buf, score_x_l_buf, ot_x_buf);
        if (left_team.points >= old_left_team_points + 2)
        {
            for (int i = 0; i < 4; i++)
            {
                if (left_team.vanquished[i] == 0)
                {
                    left_team.vanquished[i] = right_team.number;
                    break;
                }
            }
        }
        else
        {
            for (int i = 0; i < 4; i++)
            {
                if (right_team.vanquished[i] == 0)
                {
                    right_team.vanquished[i] = left_team.number;
                    break;
                }
            }
        }
        left_team.matches++;
        right_team.matches++;
        left_team.difference += Convert.ToInt32(score_x_l_buf.text) - Convert.ToInt32(score_x_r_buf.text);
        right_team.difference += Convert.ToInt32(score_x_r_buf.text) - Convert.ToInt32(score_x_l_buf.text);
        left_team.goals += Convert.ToInt32(score_x_l_buf.text);
        right_team.goals += Convert.ToInt32(score_x_r_buf.text);
        overtaking(letter_num);
    }

    void setter(Team team, int number)
    {
        team.points = 0;
        team.matches = 0;
        team.vanquished = new int[4] { 0, 0, 0, 0 };
        team.number = number;
        team.difference = 0;
        team.goals = 0;
    }

    void camera_change(int number)
    {
        if (current_cam != 228) { close_cams[current_cam].enabled = false; }
        else
        {
            if ((tour <= 11) && (first_seeing_playoff))
            {
                canvas_observer.enabled = false;
                for (int i = 0; i < 6; i++)
                {
                    obs_cams[i].enabled = false;
                }
            }
            else
            {
                canvas_playoff_observer.enabled = false;
                for (int i = 0; i < 2; i++)
                {
                    obs_cams[i].enabled = false;
                }
            }
        }
        current_cam = number;
        close_cams[current_cam].enabled = true;
    }

    int private_battles(int letter_num, int place_number_one, int place_number_two)
    {
        for (int i = 0; i < 4; i++)
        {
            if (teams_sort[letter_num, place_number_one].vanquished[i] == teams_sort[letter_num, place_number_two].number) { return 1; }
            if (teams_sort[letter_num, place_number_two].vanquished[i] == teams_sort[letter_num, place_number_one].number) { return 2; }
        }
        return 0;
    }

    void swap(int letter_num, int a, int b)
    {
        Team buf = teams_sort[letter_num, a];
        teams_sort[letter_num, a] = teams_sort[letter_num, b];
        teams_sort[letter_num, b] = buf;
    }

    void triangle (int letter_num, int start, int number_of_teams)
    {
        if ((number_of_teams != 3) || (((private_battles(letter_num, start + 0, start + 1) == 1) && (private_battles(letter_num, start + 1, start + 2) == 1)
                        && (private_battles(letter_num, start + 2, start + 0) == 1)) ||
                        ((private_battles(letter_num, start + 1, start + 0) == 1) && (private_battles(letter_num, start + 0, start + 2) == 1)
                        && (private_battles(letter_num, start + 2, start + 1) == 1))))
        {
            Team buf;
            for (int i = start; i < start + number_of_teams; i++)
            {
                for (int j = i + 1; j < start + number_of_teams; j++)
                {
                    if (teams_sort[letter_num, i].difference < teams_sort[letter_num, j].difference)
                    {
                        buf = teams_sort[letter_num, j];
                        teams_sort[letter_num, j] = teams_sort[letter_num, i];
                        teams_sort[letter_num, i] = buf;
                    }
                    else if (teams_sort[letter_num, i].difference == teams_sort[letter_num, j].difference)
                    {
                        if (teams_sort[letter_num, i].goals < teams_sort[letter_num, j].goals)
                        {
                            buf = teams_sort[letter_num, j];
                            teams_sort[letter_num, j] = teams_sort[letter_num, i];
                            teams_sort[letter_num, i] = buf;
                        }
                        else if (teams_sort[letter_num, i].goals == teams_sort[letter_num, j].goals)
                        {
                            //становится известно, что нужно делать рандом
                            //но можно на это забить и сделать типо выбралось случайным образом
                        }
                    }
                }
            }
        }
    }
}