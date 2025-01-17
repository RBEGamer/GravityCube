﻿/* Copyright (C) Team Newtons Aepfel- All Rights Reserved
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * Written by Marcel Ochsendorf <marcel.ochsendorf@gmail.com>,  
 */







using UnityEngine;
using System.Collections;

public class level_pack_mover : MonoBehaviour {


  private bool clicked;
  private Vector2 userTouch;
  public int raycast_range = 100;
  private Vector2 userMouse;
	
	// Update is called once per frame
  public Transform position_0;
  public Transform position_1;
  public Transform position_2;
  public Transform position_3;
  public Transform position_4;
  private int amount_postions = 4;
  private int current_pos;
  private Transform tmp;
  public float speed;
  public GameObject left_btn;
  public GameObject right_btn;
  public int enable_positions_to;
 

	public GameObject levelpackholder_0;
	public GameObject levelpackholder_1;
	public GameObject levelpackholder_2;
	public GameObject levelpackholder_3;
	public GameObject levelpackholder_4;


  public void move_right()
  {
    if (current_pos >= enable_positions_to) { } else { current_pos++; }
  }

  public void move_left()
  {
    if (current_pos <= 0) {  } else { current_pos--; }
}



  void Update()
  {








    if (enable_positions_to > amount_postions) { enable_positions_to = amount_postions; }

    if (current_pos <= 0)
    {
      left_btn.gameObject.SetActive(false);
    }
    else
    {
      left_btn.gameObject.SetActive(true);
    }



    if (current_pos >= enable_positions_to)
    {
      right_btn.gameObject.SetActive(false);
    }
    else
    {
      right_btn.gameObject.SetActive(true);
    }



    float step = speed * Time.deltaTime;
    switch (current_pos)
    {
      case 0:tmp = position_0;
        this.transform.position = Vector3.MoveTowards(this.transform.position, position_0.position, step);

        
          levelpackholder_0.gameObject.SetActive(true);
          levelpackholder_1.gameObject.SetActive(true);
          levelpackholder_2.gameObject.SetActive(false);
          levelpackholder_3.gameObject.SetActive(false);
          levelpackholder_4.gameObject.SetActive(false);
        


        break;



      case 1: tmp = position_1;
         this.transform.position = Vector3.MoveTowards(this.transform.position, position_1.position, step);

       
           levelpackholder_0.gameObject.SetActive(true);
           levelpackholder_1.gameObject.SetActive(true);
           levelpackholder_2.gameObject.SetActive(true);
           levelpackholder_3.gameObject.SetActive(false);
           levelpackholder_4.gameObject.SetActive(false);
         
         break;



      case 2: tmp = position_2;
         this.transform.position = Vector3.MoveTowards(this.transform.position, position_2.position, step);
        
           levelpackholder_0.gameObject.SetActive(false);
           levelpackholder_1.gameObject.SetActive(true);
           levelpackholder_2.gameObject.SetActive(true);
           levelpackholder_3.gameObject.SetActive(true);
           levelpackholder_4.gameObject.SetActive(false);
         
         break;

      case 3: tmp = position_3;
         this.transform.position = Vector3.MoveTowards(this.transform.position, position_3.position, step);
        
           levelpackholder_0.gameObject.SetActive(false);
           levelpackholder_1.gameObject.SetActive(false);
           levelpackholder_2.gameObject.SetActive(true);
           levelpackholder_3.gameObject.SetActive(true);
           levelpackholder_4.gameObject.SetActive(true);
         
         break;

      case 4: tmp = position_4;
         this.transform.position = Vector3.MoveTowards(this.transform.position, position_4.position, step);
       
           levelpackholder_0.gameObject.SetActive(false);
           levelpackholder_1.gameObject.SetActive(false);
           levelpackholder_2.gameObject.SetActive(false);
           levelpackholder_3.gameObject.SetActive(true);
           levelpackholder_4.gameObject.SetActive(true);
         
         break;



      default:current_pos = 0;break;
    }




















    //we are on a desktop device, so don't use touch
    if ( Input.GetKeyDown(KeyCode.Q))
    {
      move_left();
    }
    else if ( Input.GetKeyDown(KeyCode.E))
    {
      move_right();
    }






    if (SystemInfo.deviceType == DeviceType.Desktop)
    {
      //we are on a desktop device, so don't use touch
      if (Input.GetButtonDown("Fire1"))
      {
        userMouse = Input.mousePosition;
        Ray userTouchRayM = Camera.main.ScreenPointToRay(userMouse);
        RaycastHit raycast_infoM;
        if (Physics.Raycast(userTouchRayM, out raycast_infoM, raycast_range))
        {
          if (raycast_infoM.collider.name == left_btn.name) { move_left(); soud_manager.play_menu_click();}
        }
      }
    }
    //if it isn't a desktop, lets see if our device is a handheld device aka a mobile device
    else if (SystemInfo.deviceType == DeviceType.Handheld)
    {
      //we are on a mobile device, so lets use touch input
      if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
      {
        userTouch = Input.GetTouch(0).position;
        Ray userTouchRay = Camera.main.ScreenPointToRay(userTouch);
        RaycastHit raycast_info;
        if (Physics.Raycast(userTouchRay, out raycast_info, raycast_range))
        {
          if (raycast_info.collider.name == left_btn.name) { move_left(); soud_manager.play_menu_click();}

        }
      }
    }

















    if (SystemInfo.deviceType == DeviceType.Desktop)
    {
      //we are on a desktop device, so don't use touch
      if (Input.GetButtonDown("Fire1"))
      {
        userMouse = Input.mousePosition;
        Ray userTouchRayM = Camera.main.ScreenPointToRay(userMouse);
        RaycastHit raycast_infoM;
        if (Physics.Raycast(userTouchRayM, out raycast_infoM, raycast_range))
        {
          if (raycast_infoM.collider.name == right_btn.name) { move_right(); soud_manager.play_menu_click(); }
        }
      }
    }
    //if it isn't a desktop, lets see if our device is a handheld device aka a mobile device
    else if (SystemInfo.deviceType == DeviceType.Handheld)
    {
      //we are on a mobile device, so lets use touch input
      if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
      {
        userTouch = Input.GetTouch(0).position;
        Ray userTouchRay = Camera.main.ScreenPointToRay(userTouch);
        RaycastHit raycast_info;
        if (Physics.Raycast(userTouchRay, out raycast_info, raycast_range))
        {
          if (raycast_info.collider.name == right_btn.name) { move_right(); soud_manager.play_menu_click(); }

        }
      }
    }








  }


  void Start()
  {
    current_pos = 0;
    tmp = position_0;
  }
}
