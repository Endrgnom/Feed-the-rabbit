using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerRay : MonoBehaviour
{
    // public List<Transform>  Pointer;
    public Transform Pointer;
    private Selectable CurnetSelectable;    

        // int curentpount = 1;
        
    void LateUpdate()
    {
    //    Другой способ создания луча 
    //    Ray ray = new Ray();
    //     ray.origin = transform.position;
    //     ray.direction = transform.forward;

    // Создаёт луч из позиции 
    // Ray ray = new Ray(transform.position,transform.forward);

    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    Debug.DrawRay(transform.position,transform.forward*100,Color.yellow);

        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            // Pointer[curentpount].position = hit.point;
            Pointer.position = hit.point;

            Selectable selectable = hit.collider.gameObject.GetComponent<Selectable>();

            // Проверка на наличие скрипта
            if(selectable)
            {   
                // Проверка на раннее выделение 
                if(CurnetSelectable && CurnetSelectable != selectable){
                    CurnetSelectable.Deselect();
                }
                CurnetSelectable = selectable;
                selectable.Select();
            }
            // отключить скрипт после наведения на не заскриптованные объекты
            else{
                if(CurnetSelectable){
                    CurnetSelectable.Deselect();
                }
            }
        }
        // отключить скрипт после наведения в никуда
        else{
                if(CurnetSelectable){
                    CurnetSelectable.Deselect();
                }
            }

        // if (Input.GetMouseButtonDown(1) ){
        //     curentpount++;
        // }
        // if (curentpount>0 && Input.GetMouseButtonDown(0))
        // curentpount--;

    }
}
