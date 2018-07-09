using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameBaseObj : BaseUnityObject {

    public int instanceId = -1;
    public int confid = -1;
    public enMSCamp camp = enMSCamp.en_camp_neutral;
    bool isDie = false;

    public virtual void Init(int instanceId, int confid,enMSCamp camp){
        this.instanceId = instanceId;
        this.confid = confid;
        this.camp = camp;
    }

    public virtual bool ObjUpdate(){
        return true;
    }


    public virtual void SetDie(bool selfdie){
        isDie = true;
    }

    public virtual bool IsDie()
    {
        return isDie;
    }

    public virtual void Die(){
        Destroy(gameObject);
    }

}
