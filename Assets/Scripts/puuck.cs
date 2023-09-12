using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class puuck : MonoBehaviour
{
    public string ce_team;
    public string k_team;
    float time_timer = 60f;//60
    int number_of_times = 4;//4
    int forwards = 1;//если менять, то тоже изменить в main
    float str = 100f;
    int win_score;
    public float ce_timer = 6f;//6.6 для roads
    public float k_timer = 6f;
    float prazSpeed = 9f;
    float st_pos_Speed = 7f;
    float rarity = 0.06f;
    float door_speed = 3.5f;
    float rest_timer = 0.5f;


    public GameObject t1fw1;
    public GameObject t1fw2;
    public GameObject t1gk;
    public GameObject t2fw1;
    public GameObject t2fw2;
    public GameObject t2gk;

    public Transform trans_t1fw1;
    public Transform trans_t1fw2;
    public Transform trans_t1gk;
    public Transform trans_t2fw1;
    public Transform trans_t2fw2;
    public Transform trans_t2gk;

    public Transform spt1fw1;
    public Transform spt1fw2;
    public Transform spt1gk;
    public Transform spt2fw1;
    public Transform spt2fw2;
    public Transform spt2gk;
    public Transform sp_puck;
    public Transform ce_gateline;
    public Transform k_gateline;
    public Transform puck_hidden;
    public Transform ce_save_point;
    public Transform k_save_point;
    public Transform gate_trigger_2;
    public Transform doors_opened;
    public Transform doors_closed;
    public Transform ce_door;
    public Transform k_door;
    public Transform ce_door_exit;
    public Transform k_door_exit;
    public Transform t1fw1_hidden;
    public Transform t1fw2_hidden;
    public Transform t1gk_hidden;
    public Transform t2fw1_hidden;
    public Transform t2fw2_hidden;
    public Transform t2gk_hidden;

    public GameObject po, po1, po2, po3, po4, po5, po6, po7, po8, po9, po10, po11, po12;
    public GameObject ce_gt1, ce_gt2, k_gt1, k_gt2;

    float y0, y1, y2, x0, x1, x2, a, b, c, a1, b1, c1, a2, b2, c2, sina;
    double cd, b1d;
    
    public GameObject obj; // Directive Light
    public GameObject ce_spotlight;
    public GameObject k_spotlight;
    public GameObject ce_ps1;
    public GameObject ce_ps2;
    public GameObject k_ps1;
    public GameObject k_ps2;
    public GameObject ce_score_music;
    public GameObject k_score_music;
    public GameObject ce_win_music;
    public GameObject k_win_music;

    bool vipad;
    bool ai_t1fw1;
    bool ai_t1fw2;
    bool ai_t1gk;
    bool ai_t2fw1;
    bool ai_t2fw2;
    bool ai_t2gk;
    float ce_realtimer;
    float k_realtimer;
    float real_rest_timer;
    public bool k_win;
    public bool ce_win;
    bool bool_ce_gt;
    bool bool_k_gt;
    Light ce_light;
    Light k_light;
    int ce_score;
    int k_score;
    int time_number;
    int ot_number;
    int exit_count;
    float game_timer;
    bool ot;
    bool rest;
    double rd;
    float r;
    bool padenie_t1fw1;
    bool padenie_t1fw2;
    bool padenie_t1gk;
    bool padenie_t2fw1;
    bool padenie_t2fw2;
    bool padenie_t2gk;
    bool rasstanovka;
    bool coll;
    public Text score_text;
    public Text time_text;
    public Text ce_team_text;
    public Text k_team_text;
    public Text time_number_text;
    public Text score_text2;
    public Text time_text2;
    public Text ce_team_text2;
    public Text k_team_text2;
    public Text time_number_text2;
    public Text score_text3;
    public Text standings_ce_score; //это выключить?
    public Text standings_k_score;
    public Text standings_ot_text;
    public Text standings_time_text;
    string n;
    bool prazd;
    bool sp;
    bool t1_Gucci_Mane_left;
    bool t1_Dimebag_left;
    bool t1_rats;
    bool t2_Gucci_Mane_left;
    bool t2_Dimebag_left;
    bool t2_rats;
    bool fw1_came;
    bool fw2_came;
    bool gk_came;
    bool first_frame_rest;

    public bool need_new_game = false;

    public int number_of_arena;

    public bool text3_reverse = false;

    //public bool playoff = false; //для отладки

    void Start()
    {
        vipad = false;
        ai_t1fw1 = false;
        ai_t1fw2 = false;
        ai_t1gk = false;
        ai_t2fw1 = false;
        ai_t2fw2 = false;
        ai_t2gk = false;
        k_win = false;
        ce_win = false;
        bool_ce_gt = false;
        bool_k_gt = false;
        time_number = 1;
        ot_number = 0;
        exit_count = 0;
        ce_score = 0;//0 //инициализация здесь, т.к. Start будет вызываться несколько раз
        k_score = 0;
        //if (playoff) { k_score = 1; } //отладка
        //else { k_score = 0; }
        ot = false;
        rest = false;
        coll = false;
        prazd = false;
        sp = false;
        t1_Gucci_Mane_left = false;
        t1_Dimebag_left = false;
        t1_rats = false;
        t2_Gucci_Mane_left = false;
        t2_Dimebag_left = false;
        t2_rats = false;
        fw1_came = false;
        fw2_came = false;
        gk_came = false;
        first_frame_rest = true;
        //инизилизация закончена

        padenie_t1fw1 = true;//разобраться как работают эти переменные, мб из этого вытекают баги
        padenie_t1fw2 = true;
        padenie_t1gk = true;
        padenie_t2fw1 = true;
        padenie_t2fw2 = true;
        padenie_t2gk = true;
        ce_ps1.gameObject.SetActive(false);
        ce_ps2.gameObject.SetActive(false);
        k_ps1.gameObject.SetActive(false);
        k_ps2.gameObject.SetActive(false);
        ce_win_music.gameObject.SetActive(false);
        k_win_music.gameObject.SetActive(false);
        Light my_light = ce_spotlight.GetComponent<Light>();
        my_light.enabled = false;
        my_light = ce_spotlight.GetComponent<Light>();
        my_light.enabled = false;
        //поле убрано с прошлой игры

        game_timer = time_timer;

        score_text.text = ce_score + "-" + k_score/*.ToString()*/;
        time_text.text = (game_timer / 60 - (game_timer / 60) % 1) + ":" + (game_timer % 60 - (game_timer % 60) % 1);
        ce_team_text.text = ce_team;
        k_team_text.text = k_team;
        time_number_text.text = time_number.ToString();

        score_text2.text = ce_score + "-" + k_score/*.ToString()*/;
        time_text2.text = (game_timer / 60 - (game_timer / 60) % 1) + ":" + (game_timer % 60 - (game_timer % 60) % 1);
        ce_team_text2.text = ce_team;
        k_team_text2.text = k_team;
        time_number_text2.text = time_number.ToString();

        if (number_of_arena <= 2)
        {
            if (!text3_reverse) { score_text3.text = ce_score + "-" + k_score; }
            else { score_text3.text = k_score + "-" + ce_score; }
        }

        standings_ce_score.text = ce_score.ToString();
        standings_k_score.text = k_score.ToString();

        ce_realtimer = ce_timer;
        k_realtimer = k_timer;
        real_rest_timer = rest_timer;

        t1fw1.transform.position = spt1fw1.transform.position;
        t1gk.transform.position = spt1gk.transform.position;
        t2fw1.transform.position = spt2fw1.transform.position;
        t2gk.transform.position = spt2gk.transform.position;
        if (forwards != 1)
        {
            t1fw2.transform.position = spt1fw2.transform.position;
            t2fw2.transform.position = spt2fw2.transform.position;
        }

        ai_true();
        vbrasivanie();
    }

    //поменять цвет лайва на жёлтый
    void FixedUpdate() // сделать так, чтоб смотрелся какой-то параметр, говорящий что надо ребутать скрипт, и ребутать
    {
        //print(t1fw1.transform.rotation.eulerAngles.x);
        //float dist = Vector3.Distance(t1fw1.transform.position, transform.position);
        //print("dist = " + dist);

        if (need_new_game)
        {
            Start();
            need_new_game = false;
        }

        if ((!ce_win) && (!k_win))
        {
            if (time_number_text.text == "1") { standings_time_text.text = "Live 1st " + time_text.text; }
            else if ((time_number_text.text == "2") && (rest)) { standings_time_text.text = "Live 2nd Break"; }
            else if ((time_number_text.text == "2") && (!rest)) { standings_time_text.text = "Live 2nd " + time_text.text; }
            else if ((time_number_text.text == "3") && (rest)) { standings_time_text.text = "Live 3rd Break"; }
            else if ((time_number_text.text == "3") && (!rest)) { standings_time_text.text = "Live 3rd " + time_text.text; }
            else if ((time_number_text.text == "4") && (rest)) { standings_time_text.text = "Live 4th Break"; }
            else if ((time_number_text.text == "4") && (!rest)) { standings_time_text.text = "Live 4th " + time_text.text; }
            else if ((ot) && (!rest)) { standings_time_text.text = "Live " + time_number_text.text + " " + time_text.text; }
            else if ((ot) && (rest)) { standings_time_text.text = "Live " + time_number_text.text + " Break"; }
        }

        if (game_timer % 60 - (game_timer % 60) % 1 < 10) { n = "0"; }
        else { n = ""; }
        if ((!bool_k_gt) && (!bool_ce_gt) && (!vipad) && (coll)) { game_timer -= 0.02f; }
        if (!ot)
        {
            time_number_text.text = time_number.ToString();
            time_number_text2.text = time_number.ToString();
        }
        if (game_timer > 0)
        {
            time_text.text = (game_timer / 60 - (game_timer / 60) % 1) + ":" + n + (game_timer % 60 - (game_timer % 60) % 1);
            time_text2.text = (game_timer / 60 - (game_timer / 60) % 1) + ":" + n + (game_timer % 60 - (game_timer % 60) % 1);
        }
        if ((game_timer <= 0) && (!ce_win) && (!k_win))
        {
            if (time_number >= number_of_times)
            {
                if (k_score > ce_score)
                {
                    k_win = true;
                    standings_time_text.text = "Finished";
                }
                else if (ce_score > k_score)
                {
                    ce_win = true;
                    standings_time_text.text = "Finished";
                }
                else
                {
                    //perehod_vipad_reaction();
                    rest = true;
                    ot_number++;
                    time_number++;
                    ot = true;
                    game_timer = time_timer;
                    standings_ot_text.text = "OT";
                    
                    if ((ot_number == 1) && (number_of_arena <= 2)) { score_text3.text += " (OT)"; }
                }
            }
            else
            {
                //perehod_vipad_reaction();
                rest = true;
                time_number++;
                game_timer = time_timer;
            }
        }
        if ((ot) && (!k_win) && (!ce_win))
        {
            if (ot_number == 1)
            {
                time_number_text.text = "OT";
                time_number_text2.text = "OT";
            }
            else
            {
                time_number_text.text = "OT" + ot_number;
                time_number_text2.text = "OT" + ot_number;
            }
            time_text.text = (game_timer / 60 - (game_timer / 60) % 1) + ":" + n + (game_timer % 60 - (game_timer % 60) % 1);
            time_text2.text = (game_timer / 60 - (game_timer / 60) % 1) + ":" + n + (game_timer % 60 - (game_timer % 60) % 1);
            //time_text.text = "+" + Math.Abs((game_timer / 60 - (game_timer / 60) % 1)) + ":" + n + Math.Abs((game_timer % 60 - (game_timer % 60) % 1));
            //time_text2.text = "+" + Math.Abs((game_timer / 60 - (game_timer / 60) % 1)) + ":" + n + Math.Abs((game_timer % 60 - (game_timer % 60) % 1));
            if (k_score > ce_score)
            {
                k_win = true;
                standings_time_text.text = "Finished";
            }
            else if (ce_score > k_score)
            {
                ce_win = true;
                standings_time_text.text = "Finished";
            }
        }
        

        if (rest)
        {
            if (first_frame_rest)
            {
                vipad = true;
                ai_false();
            }
            first_frame_rest = false;
            
            if (real_rest_timer == rest_timer)
            {
                ce_door.transform.position = Vector3.MoveTowards(ce_door.transform.position, new Vector3(ce_door.transform.position.x, doors_opened.transform.position.y, ce_door.transform.position.z), Time.deltaTime * door_speed);
                k_door.transform.position = Vector3.MoveTowards(k_door.transform.position, new Vector3(k_door.transform.position.x, doors_opened.transform.position.y, k_door.transform.position.z), Time.deltaTime * door_speed);
            }

            if (((forwards == 1) && t1_Gucci_Mane_left && t1_rats && t2_Gucci_Mane_left && t2_rats) ||
                ((forwards == 2) && t1_Gucci_Mane_left && t1_Dimebag_left && t1_rats && t2_Gucci_Mane_left && t1_Dimebag_left && t2_rats))
            {
                if (real_rest_timer == rest_timer)
                {
                    Material mat_t1fw1 = t1fw1.GetComponent<Renderer>().material;
                    t1fw1.GetComponent<Renderer>().material = t2fw1.GetComponent<Renderer>().material;
                    t2fw1.GetComponent<Renderer>().material = mat_t1fw1;

                    Material mat_t1gk = t1gk.GetComponent<Renderer>().material;
                    t1gk.GetComponent<Renderer>().material = t2gk.GetComponent<Renderer>().material;
                    t2gk.GetComponent<Renderer>().material = mat_t1gk;

                    if (forwards == 2)
                    {
                        Material mat_t1fw2 = t1fw2.GetComponent<Renderer>().material;
                        t1fw2.GetComponent<Renderer>().material = t2fw2.GetComponent<Renderer>().material;
                        t2fw2.GetComponent<Renderer>().material = mat_t1fw2;
                    }
                }

                real_rest_timer -= 0.02f;

                if (real_rest_timer <= 0f)
                {
                    if (!fw1_came) //возможно здесь выход на арену
                    {
                        if (time_number % 2 != 0)
                        {
                            t1fw1.transform.position = ce_door_exit.transform.position;
                            t2fw1.transform.position = k_door_exit.transform.position;
                        }
                        else
                        {
                            t1fw1.transform.position = k_door_exit.transform.position;
                            t2fw1.transform.position = ce_door_exit.transform.position;
                        }
                    }
                    fw1_came = true;

                    t1fw1.transform.position = Vector3.MoveTowards(t1fw1.transform.position, spt1fw1.position, Time.deltaTime * st_pos_Speed);
                    t2fw1.transform.position = Vector3.MoveTowards(t2fw1.transform.position, spt2fw1.position, Time.deltaTime * st_pos_Speed);
                }
                else { fw1_came = false; }

                if ((real_rest_timer <= -1f) && (forwards == 2))
                {
                    if (!fw2_came)
                    {
                        if (time_number % 2 != 0)
                        {
                            t1fw2.transform.position = ce_door_exit.transform.position;
                            t2fw2.transform.position = k_door_exit.transform.position;
                        }
                        else
                        {
                            t1fw2.transform.position = k_door_exit.transform.position;
                            t2fw2.transform.position = ce_door_exit.transform.position;
                        }
                    }
                    fw2_came = true;

                    t1fw2.transform.position = Vector3.MoveTowards(t1fw2.transform.position, spt1fw2.position, Time.deltaTime * st_pos_Speed);
                    t2fw2.transform.position = Vector3.MoveTowards(t2fw2.transform.position, spt2fw2.position, Time.deltaTime * st_pos_Speed);
                }
                else { fw2_came = false; }

                if (((real_rest_timer <= -2f) && (forwards == 2)) || ((real_rest_timer <= -1f) && (forwards == 1)))
                {
                    if (!gk_came)
                    {
                        if (time_number % 2 != 0)
                        {
                            t1gk.transform.position = ce_door_exit.transform.position;
                            t2gk.transform.position = k_door_exit.transform.position;
                        }
                        else
                        {
                            t1gk.transform.position = k_door_exit.transform.position;
                            t2gk.transform.position = ce_door_exit.transform.position;
                        }
                    }
                    gk_came = true;

                    t1gk.transform.position = Vector3.MoveTowards(t1gk.transform.position, spt1gk.position, Time.deltaTime * st_pos_Speed);
                    t2gk.transform.position = Vector3.MoveTowards(t2gk.transform.position, spt2gk.position, Time.deltaTime * st_pos_Speed);
                }
                else { gk_came = false; }

                if (((real_rest_timer <= -3f) && (forwards == 2)) || ((real_rest_timer <= -2f) && (forwards == 1)))
                {
                    ce_door.transform.position = Vector3.MoveTowards(ce_door.transform.position, new Vector3(ce_door.transform.position.x, doors_closed.transform.position.y, ce_door.transform.position.z), Time.deltaTime * door_speed);
                    k_door.transform.position = Vector3.MoveTowards(k_door.transform.position, new Vector3(k_door.transform.position.x, doors_closed.transform.position.y, k_door.transform.position.z), Time.deltaTime * door_speed);
                }
            }
            else
            {
                if (time_number % 2 != 0)
                {
                    rest_position(trans_t2fw1, trans_t2fw2, trans_t2gk, trans_t1fw1, trans_t1fw2, trans_t1gk);
                }
                else
                {
                    rest_position(trans_t1fw1, trans_t1fw2, trans_t1gk, trans_t2fw1, trans_t2fw2, trans_t2gk);
                }
            }

        }
        else { first_frame_rest = true; }


        if (sp)
        {
            start_position(trans_t1fw1, trans_t1fw2, trans_t1gk, trans_t2fw1, trans_t2fw2, trans_t2gk,
            spt1fw1, spt1fw2, spt1gk, spt2fw1, spt2fw2, spt2gk);
        }

        if (!prazd)
        {
            padenie_t1fw1 = pad(t1fw1, padenie_t1fw1); padenie_t1fw2 = pad(t1fw2, padenie_t1fw2); padenie_t1gk = pad(t1gk, padenie_t1gk);
            padenie_t2fw1 = pad(t2fw1, padenie_t2fw1); padenie_t2fw2 = pad(t2fw2, padenie_t2fw2); padenie_t2gk = pad(t2gk, padenie_t2gk);
        }
        padenie_t1fw1 = save(t1fw1, padenie_t1fw1); padenie_t1fw2 = save(t1fw2, padenie_t1fw2); padenie_t1gk = save(t1gk, padenie_t1gk);
        padenie_t2fw1 = save(t2fw1, padenie_t2fw1); padenie_t1fw1 = save(t2fw2, padenie_t1fw1); padenie_t1fw1 = save(t2gk, padenie_t1fw1);

        if (((forwards != 1) && (t1fw1.transform.position == spt1fw1.transform.position) && (t1fw2.transform.position == spt1fw2.transform.position)
            && (t1gk.transform.position == spt1gk.transform.position) && (t2fw1.transform.position == spt2fw1.transform.position)
            && (t2fw2.transform.position == spt2fw2.transform.position) && (t2gk.transform.position == spt2gk.transform.position)) ||
            ((forwards == 1) && (t1fw1.transform.position == spt1fw1.transform.position) && (t1gk.transform.position == spt1gk.transform.position)
            && (t2fw1.transform.position == spt2fw1.transform.position) && (t2gk.transform.position == spt2gk.transform.position)))
        { rasstanovka = true; }
        else { rasstanovka = false; }

        //костыль от выпадения шайбы сквозь стену или улетания вверх
        if ((!bool_ce_gt) && (!bool_k_gt) && (!vipad))
        {
            if (transform.position.y < gate_trigger_2.transform.position.y/*2f*/)
            {
                vipad_reaction();
                print("Pozorishche");
            }
        }

        if ((vipad) && (rasstanovka))
        {
            real_rest_timer = rest_timer;
            t1_Gucci_Mane_left = false;
            t1_Dimebag_left = false;
            t1_rats = false;
            t2_Gucci_Mane_left = false;
            t2_Dimebag_left = false;
            t2_rats = false;
            rest = false;

            //sp = false;
            vipad = false;
            vbrasivanie();
            ai_true();
        }

        if (k_win)
        {
            //k_realtimer -= 0.02f;

            ai_false();

            //слэм открыт
            if (time_number % 2 != 0)
            {
                prazdnovanie(trans_t2fw1, trans_t2fw2, trans_t2gk, prazSpeed, forwards);
                k_win_music.gameObject.SetActive(true);
            }
            else
            {
                prazdnovanie(trans_t1fw1, trans_t1fw2, trans_t1gk, prazSpeed, forwards);
                ce_win_music.gameObject.SetActive(true);
            }
            prazd = true;

            ce_ps1.gameObject.SetActive(true);
            ce_ps2.gameObject.SetActive(true);
            k_ps1.gameObject.SetActive(true);
            k_ps2.gameObject.SetActive(true);

            //Light ce_light = ce_spotlight.GetComponent<Light>();
            //if ((k_realtimer % rarity >= 0f) && (k_realtimer % rarity < 0.001f) && (k_realtimer > 0f))
            //{
            //    ce_light.enabled = !ce_light.enabled;
            //}
            //if (k_realtimer <= 0f)
            //{
            //    ce_light.enabled = false;
            //}
        }

        if (ce_win)
        {
            //ce_realtimer -= 0.02f;

            ai_false();

            //слэм открыт
            if (time_number % 2 != 0)
            {
                prazdnovanie(trans_t1fw1, trans_t1fw2, trans_t1gk, prazSpeed, forwards);
                ce_win_music.gameObject.SetActive(true);
            }
            else
            {
                prazdnovanie(trans_t2fw1, trans_t2fw2, trans_t2gk, prazSpeed, forwards);
                k_win_music.gameObject.SetActive(true);
            }
            prazd = true;

            k_ps1.gameObject.SetActive(true);
            k_ps2.gameObject.SetActive(true);
            ce_ps1.gameObject.SetActive(true);
            ce_ps2.gameObject.SetActive(true);

            //Light k_light = k_spotlight.GetComponent<Light>();
            //if ((ce_realtimer % rarity >= 0f) && (ce_realtimer % rarity < 0.001f) && (ce_realtimer > 0f))
            //{
            //    k_light.enabled = !k_light.enabled;
            //}
            //if (k_realtimer <= 0f)
            //{
            //    k_light.enabled = false;
            //}
        }

        if ((bool_ce_gt) && (!ce_win) && (!k_win))
        {
            k_realtimer = goal(k_realtimer, k_timer, k_score_music, trans_t2fw1, trans_t2fw2, trans_t2gk,
                               ce_ps1, ce_ps2, ce_spotlight);
            if (k_realtimer == k_timer) { bool_ce_gt = false; }
        }

        if ((bool_k_gt) && (!ce_win) && (!k_win))
        {
            ce_realtimer = goal(ce_realtimer, ce_timer, ce_score_music, trans_t1fw1, trans_t1fw2, trans_t1gk,
                                k_ps1, k_ps2, k_spotlight);
            if (ce_realtimer == ce_timer) { bool_k_gt = false; }
        }
    }

    void OnCollisionStay(Collision other)
    {
        coll = true;

        if (other.gameObject.name == t1fw1.name) { tolchok(t1fw1); }
        if (other.gameObject.name == t1fw2.name) { tolchok(t1fw2); }
        if (other.gameObject.name == t1gk.name) { tolchok(t1gk); }
        if (other.gameObject.name == t2fw1.name) { tolchok(t2fw1); }
        if (other.gameObject.name == t2fw2.name) { tolchok(t2fw2); }
        if (other.gameObject.name == t1gk.name) { tolchok(t1gk); }

        /*if (other.gameObject.name == t1fw1.name || other.gameObject.name == t1fw2.name || other.gameObject.name == t1gk.name ||
            other.gameObject.name == t2fw1.name || other.gameObject.name == t2fw2.name || other.gameObject.name == t2gk.name)
        {
            y2 = other.gameObject.transform.position.z;
            x2 = other.gameObject.transform.position.x;
            y1 = transform.position.z;
            x1 = transform.position.x;
            a = Math.Abs(x1 - x2);
            b = Math.Abs(y1 - y2);
            cd = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
            c = (float)cd;
            sina = a / c;
            a1 = 100;
            c1 = a1 / sina;
            b1d = Math.Sqrt(Math.Pow(c1, 2) - Math.Pow(a1, 2));
            b1 = (float)b1d;
            if (x1 > x2) { x0 = x2 + a1; }
            else { x0 = x2 - a1; }
            if (y1 > y2) { y0 = y2 + b1; }
            else { y0 = y2 - b1; }

            GetComponent<Rigidbody>().AddForce(x0, 3.730925f, y0);
            //возможно если изменить x0 и y0, шайба изменит скорость
        }*/
    }

    void tolchok(GameObject other)
    {
        y2 = other.gameObject.transform.localPosition.z;
        x2 = other.gameObject.transform.localPosition.x;
        y1 = transform.localPosition.z;
        x1 = transform.localPosition.x;
        a = Math.Abs(x1 - x2);
        b = Math.Abs(y1 - y2);
        cd = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
        c = (float)cd;
        c2 = c + str;
        a2 = a * c2 / c;
        b2 = b * c2 / c;
        if (x1 > x2) { x0 = x2 + a2; }
        else { x0 = x2 - a2; }
        if (y1 > y2) { y0 = y2 + b2; }
        else { y0 = y2 - b2; }

        /*sina = a / c;
        a1 = 100;
        c1 = a1 / sina;
        b1d = Math.Sqrt(Math.Pow(c1, 2) - Math.Pow(a1, 2));
        b1 = (float)b1d;
        if (x1 > x2) { x0 = x2 + a1; }
        else { x0 = x2 - a1; }
        if (y1 > y2) { y0 = y2 + b1; }
        else { y0 = y2 - b1; }*/

        //надо ли добавлять Time.deltaTime ?
        GetComponent<Rigidbody>().AddForce(x0, other.gameObject.transform.localPosition.y, y0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == po.name || other.gameObject.name == po1.name || other.gameObject.name == po2.name ||
            other.gameObject.name == po3.name || other.gameObject.name == po4.name || other.gameObject.name == po5.name ||
            other.gameObject.name == po6.name || other.gameObject.name == po7.name || other.gameObject.name == po8.name ||
            other.gameObject.name == po9.name || other.gameObject.name == po10.name || other.gameObject.name == po11.name ||
            other.gameObject.name == po12.name)
        {
            vipad_reaction();
        }

        if (((other.gameObject.name == ce_gt1.name) || (other.gameObject.name == ce_gt2.name)) && (!vipad) && (!ce_win) && (!k_win))
        {
            if (!bool_ce_gt)
            {
                if (time_number % 2 != 0)
                {
                    k_score++;
                    standings_k_score.text = k_score.ToString();
                }
                else
                {
                    ce_score++;
                    standings_ce_score.text = ce_score.ToString();
                }
                score_text.text = ce_score + "-" + k_score;
                score_text2.text = ce_score + "-" + k_score;
                if (number_of_arena <= 2)
                {
                    if (!text3_reverse) { score_text3.text = ce_score + "-" + k_score; }
                    else { score_text3.text = k_score + "-" + ce_score; }

                    if (ot) { score_text3.text += " (OT)"; }
                }
            }
            bool_ce_gt = true;
        }

        if (((other.gameObject.name == k_gt1.name) || (other.gameObject.name == k_gt2.name)) && (!vipad) && (!ce_win) && (!k_win))
        {
            if (!bool_k_gt)
            {
                if (time_number % 2 != 0)
                {
                    ce_score++;
                    standings_ce_score.text = ce_score.ToString();
                }
                else
                {
                    k_score++;
                    standings_k_score.text = k_score.ToString();
                }
                score_text.text = ce_score + "-" + k_score/*.ToString()*/;
                score_text2.text = ce_score + "-" + k_score;
                if (number_of_arena <= 2)
                {
                    if (!text3_reverse) { score_text3.text = ce_score + "-" + k_score; }
                    else { score_text3.text = k_score + "-" + ce_score; }

                    if (ot) { score_text3.text += " (OT)"; }
                }
            }
            bool_k_gt = true;
            //if (ce_score == win_score) { ce_win = true; }
        }
    }

    bool save(GameObject cap, bool padenie)
    {
        if (cap.transform.position.y < gate_trigger_2.transform.position.y/*3f*/)
        {
            Rigidbody rb1 = cap.GetComponent<Rigidbody>();
            rb1.isKinematic = true;
            cap.transform.rotation = Quaternion.Euler(0, 90, 0);
            if (cap.transform.position.x > sp_puck.transform.position.x/*7.846141f*/)
            { cap.transform.position = ce_save_point.transform.position/*new Vector3(21.947f, 4.354f, -10.31f)*/; }
            else { cap.transform.position = k_save_point.transform.position/*new Vector3(-6.253f, 4.354f, -10.31f)*/; }
            rb1.isKinematic = false;
            padenie = false;
        }
        return padenie;
    }

    void vipad_reaction()
    {
        transform.position = puck_hidden.transform.position;
        sp = true;
        vipad = true;
        ai_false();
    }

    //void perehod_vipad_reaction()
    //{
    //    //ce_door.transform.position = Vector3.MoveTowards(ce_door.transform.position, new Vector3(ce_door.transform.position.x, doors_opened.transform.position.y, ce_door.transform.position.z), Time.deltaTime * door_speed);
    //    //k_door.transform.position = Vector3.MoveTowards(k_door.transform.position, new Vector3(k_door.transform.position.x, doors_opened.transform.position.y, k_door.transform.position.z), Time.deltaTime * door_speed);


    //    sp = true;
    //    vipad = true;
    //    ai_false();
    //}

    void vbrasivanie()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        System.Random rand = new System.Random();
        rd = Convert.ToDouble(rand.Next(10000)) / 1000;
        r = (float)rd;
        transform.position = new Vector3(sp_puck.transform.position.x, sp_puck.transform.position.y + r, sp_puck.transform.position.z);
        print("r = " + r);
        rb.isKinematic = false;
        coll = false;
    }

    bool pad(GameObject cap, bool padenie)//мб не надо присваивать  //Здесь постоянно ищет Rigidbody!!!!! Надо от этого избавиться!
    {
        if ((cap.transform.position.x >= ce_gateline.transform.position.x) || (cap.transform.position.x <= k_gateline.transform.position.x)) 
        {
            Rigidbody rb = cap.GetComponent<Rigidbody>();
            rb.constraints = RigidbodyConstraints.None;
            padenie = true;
        }
        else
        {
            Rigidbody rb = cap.GetComponent<Rigidbody>();
            rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            if (padenie) { cap.transform.rotation = Quaternion.Euler(0, 90, 0); }
            else { padenie = false; }
            //if (cap.transform.rotation.eulerAngles.x < 1)
            //{
            //    cap.transform.rotation = Quaternion.Euler(0, 90, 0);
            //}
            //else { padenie = false; }
        }
        return padenie; 
    }

    void prazdnovanie(Transform f1, Transform f2, Transform gk, float prazSpeed, int forwards)
    {
        Rigidbody rb1 = f1.GetComponent<Rigidbody>();
        Rigidbody rb2 = f2.GetComponent<Rigidbody>();
        Rigidbody rb3 = gk.GetComponent<Rigidbody>();
        rb1.constraints = RigidbodyConstraints.None;
        rb2.constraints = RigidbodyConstraints.None;
        rb3.constraints = RigidbodyConstraints.None;
        
        f1.transform.position = Vector3.MoveTowards(f1.transform.position, gk.position, Time.deltaTime * prazSpeed);
        gk.transform.position = Vector3.MoveTowards(gk.transform.position, f1.position, Time.deltaTime * prazSpeed);
        if (forwards == 2)
        {
            f2.transform.position = Vector3.MoveTowards(f2.transform.position, f1.position, Time.deltaTime * prazSpeed);
            f1.transform.position = Vector3.MoveTowards(f1.transform.position, f2.position, Time.deltaTime * prazSpeed);
            f2.transform.position = Vector3.MoveTowards(f2.transform.position, gk.position, Time.deltaTime * prazSpeed);
            gk.transform.position = Vector3.MoveTowards(gk.transform.position, f2.position, Time.deltaTime * prazSpeed);
        }
    }

    void start_position(Transform t1fw1, Transform t1fw2, Transform t1gk, Transform t2fw1, Transform t2fw2, Transform t2gk,
                   Transform spt1fw1, Transform spt1fw2, Transform spt1gk, Transform spt2fw1, Transform spt2fw2, Transform spt2gk)
    {
        t1fw1.transform.position = Vector3.MoveTowards(t1fw1.transform.position, spt1fw1.position, Time.deltaTime * st_pos_Speed);
        t1gk.transform.position = Vector3.MoveTowards(t1gk.transform.position, spt1gk.position, Time.deltaTime * st_pos_Speed);
        t2fw1.transform.position = Vector3.MoveTowards(t2fw1.transform.position, spt2fw1.position, Time.deltaTime * st_pos_Speed);
        t2gk.transform.position = Vector3.MoveTowards(t2gk.transform.position, spt2gk.position, Time.deltaTime * st_pos_Speed);

        if (forwards != 1)
        {
            t1fw2.transform.position = Vector3.MoveTowards(t1fw2.transform.position, spt1fw2.position, Time.deltaTime * st_pos_Speed);
            t2fw2.transform.position = Vector3.MoveTowards(t2fw2.transform.position, spt2fw2.position, Time.deltaTime * st_pos_Speed);
        }
    }

    void rest_position(Transform t1fw1, Transform t1fw2, Transform t1gk, Transform t2fw1, Transform t2fw2, Transform t2gk)
    {
        if ((t1fw1.transform.position.x >= ce_door_exit.transform.position.x - 0.02f) && (t1fw1.transform.position.z >= ce_door_exit.transform.position.z - 0.02f))
        {
            t1fw1.transform.position = t1fw1_hidden.transform.position;
            t1_Gucci_Mane_left = true;
        }
        else if (!t1_Gucci_Mane_left) { t1fw1.transform.position = Vector3.MoveTowards(t1fw1.transform.position, ce_door_exit.position, Time.deltaTime * st_pos_Speed); }

        if ((t1gk.transform.position.x >= ce_door_exit.transform.position.x - 0.02f) && (t1gk.transform.position.z >= ce_door_exit.transform.position.z - 0.02f))
        {
            t1gk.transform.position = t1gk_hidden.transform.position;
            t1_rats = true;
        }
        else if (!t1_rats) { t1gk.transform.position = Vector3.MoveTowards(t1gk.transform.position, ce_door_exit.position, Time.deltaTime * st_pos_Speed); }

        if ((t2fw1.transform.position.x <= k_door_exit.transform.position.x + 0.02f) && (t2fw1.transform.position.z <= k_door_exit.transform.position.z + 0.02f))
        {
            t2fw1.transform.position = t2fw1_hidden.transform.position;
            t2_Gucci_Mane_left = true;
        }
        else if (!t2_Gucci_Mane_left) { t2fw1.transform.position = Vector3.MoveTowards(t2fw1.transform.position, k_door_exit.position, Time.deltaTime * st_pos_Speed); }

        if ((t2gk.transform.position.x <= k_door_exit.transform.position.x + 0.02f) && (t2gk.transform.position.z <= k_door_exit.transform.position.z + 0.02f))
        {
            t2gk.transform.position = t2gk_hidden.transform.position;
            t2_rats = true;
        }
        else if (!t2_rats) { t2gk.transform.position = Vector3.MoveTowards(t2gk.transform.position, k_door_exit.position, Time.deltaTime * st_pos_Speed); }
        
        if (forwards != 1)
        {
            if ((t1fw2.transform.position.x >= ce_door_exit.transform.position.x - 0.02f) && (t1fw2.transform.position.z >= ce_door_exit.transform.position.z - 0.02f))
            {
                t1fw2.transform.position = t1fw2_hidden.transform.position;
                t1_Dimebag_left = true;
            }
            else if (!t1_Dimebag_left) { t1fw2.transform.position = Vector3.MoveTowards(t1fw2.transform.position, ce_door_exit.position, Time.deltaTime * st_pos_Speed); }

            if ((t2fw2.transform.position.x <= k_door_exit.transform.position.x + 0.02f) && (t2fw2.transform.position.z <= k_door_exit.transform.position.z + 0.02f))
            {
                t2fw2.transform.position = t2fw2_hidden.transform.position;
                t2_Dimebag_left = true;
            }
            else if (!t2_Dimebag_left) { t2fw2.transform.position = Vector3.MoveTowards(t2fw2.transform.position, k_door_exit.position, Time.deltaTime * st_pos_Speed); }
        }
    }

    void ai_true()
    {
        AI scr_t1fw1 = t1fw1.GetComponent<AI>();
        AI scr_t2fw1 = t2fw1.GetComponent<AI>();
        //AI scr_t1fw2 = t1fw2.GetComponent<AI>();
        //AI scr_t2fw2 = t2fw2.GetComponent<AI>();
        AI_gk scr_t1gk = t1gk.GetComponent<AI_gk>();
        AI_gk scr_t2gk = t2gk.GetComponent<AI_gk>();
        /*if (ai_t1fw1)*/ { scr_t1fw1.enabled = true; }
        /*if (ai_t2fw1)*/ { scr_t2fw1.enabled = true; }
        //if (ai_t1fw2) { scr_t1fw2.enabled = true; }
        //if (ai_t2fw2) { scr_t2fw2.enabled = true; }
        /*if (ai_t1gk)*/ { scr_t1gk.enabled = true; }
        /*if (ai_t2gk)*/ { scr_t2gk.enabled = true; }
    }

    void ai_false() // здесь get component убирается на изи
    {
        AI scr_t1fw1 = t1fw1.GetComponent<AI>();
        AI scr_t2fw1 = t2fw1.GetComponent<AI>();
        //AI scr_t1fw2 = t1fw2.GetComponent<AI>();
        //AI scr_t2fw2 = t2fw2.GetComponent<AI>();
        AI_gk scr_t1gk = t1gk.GetComponent<AI_gk>();
        AI_gk scr_t2gk = t2gk.GetComponent<AI_gk>();
        //if (scr_t1fw1.enabled)
        {
            //ai_t1fw1 = true;
            scr_t1fw1.enabled = false;
        }
        //if (scr_t2fw1.enabled)
        {
            //ai_t2fw1 = true;
            scr_t2fw1.enabled = false;
        }
        //if (scr_t1fw2.enabled)
        {
            //ai_t1fw2 = true;
            //scr_t1fw2.enabled = false;
        }
        //if (scr_t2fw2.enabled)
        {
            //ai_t2fw2 = true;
            //scr_t2fw2.enabled = false;
        }
        //if (scr_t1gk.enabled)
        {
            //ai_t1gk = true;
            scr_t1gk.enabled = false;
        }
        //if (scr_t2gk.enabled)
        {
            //ai_t2gk = true;
            scr_t2gk.enabled = false;
        }
    }

    float goal(float s_realtimer, float s_timer, GameObject s_score_music,
              Transform s_trans_fw1, Transform s_trans_fw2, Transform s_trans_gk,
              GameObject m_ps1, GameObject m_ps2, GameObject m_spotlight)
    {
        s_realtimer -= 0.02f;
        
        if (s_realtimer > 0f)
        {
            ai_false();

            //слэм открыт
            prazdnovanie(s_trans_fw1, s_trans_fw2, s_trans_gk, prazSpeed, forwards);
            prazd = true;

            s_score_music.gameObject.SetActive(true);

            m_ps1.gameObject.SetActive(true);
            m_ps2.gameObject.SetActive(true);

            if ((s_realtimer % rarity >= 0f) && (s_realtimer % rarity < 0.001f))
            {
                Light my_light = m_spotlight.GetComponent<Light>();
                my_light.enabled = !my_light.enabled;
            }
        }

        if (s_realtimer <= 0f)
        {
            //слэм закрыт
            prazd = false;
            padenie_t1fw1 = true;
            padenie_t1fw2 = true;
            padenie_t1gk = true;
            padenie_t2fw1 = true;
            padenie_t2fw2 = true;
            padenie_t2gk = true;

            s_score_music.gameObject.SetActive(false);

            m_ps1.gameObject.SetActive(false);
            m_ps2.gameObject.SetActive(false);

            Light my_light = m_spotlight.GetComponent<Light>();
            my_light.enabled = false;

            sp = true;

            if (rasstanovka)
            {
                s_realtimer = s_timer;
                vbrasivanie();
                sp = false;
                ai_true();
            }
        }

        return s_realtimer;
    }
}