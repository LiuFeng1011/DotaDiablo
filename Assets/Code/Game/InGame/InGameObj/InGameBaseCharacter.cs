using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public enum enCharacterProperty
{
    non,
    //strength,//力量 1攻击力
    //agility,//敏捷 0.01攻击速度，0.005闪避 0.01移动速度
    //brains,//智力 0.01释放技能概率 
    //stamina,//体力 生命恢复速度 10生命最大值

    life = 1 ,//生命
    liferevive = 2,  /*  生命回复    */

    atkForce = 3,//攻击力

    atkSpeed = 4,    /*  攻击速度  */
    moveSpeed = 5,   /*  移动速度  */

    comborate = 6,   /*  暴击几率    */
    comboval = 7,    /*  暴击伤害    */
    armor = 8,   /*  护甲  */
    avoid = 9,   /*  闪避  */
    returnhurt = 10,  /*  反弹伤害    */
    steallife = 11,   /*  偷取生命    */
    golddrop = 12,    /*  金币掉率加成  */
    equipdrop = 13,   /*  魔法物品掉率  */

    lifeAddition = 15,   /*  生命加成  */
    armorAddition = 16,   /*  护甲加成  */
    moveSpeedAddition = 17,   /*  移动速度加成  */
    atkSpeedAddition = 18,    /*  攻击速度加成  */
    atkForceAddition = 19,      /*  攻击力加成  */
    maxval,
}

[System.Serializable]
public class CharacterProperty{
    
    public float[] propertyValues = new float[(int)enCharacterProperty.maxval];

    public void SetProperty(enCharacterProperty type, float val){
        propertyValues[(int)type] = val;
    }

    public void AdditionProperty(enCharacterProperty type, float val)
    {
        propertyValues[(int)type] =+ val;
    }

    public float GetProperty(enCharacterProperty type){
        return propertyValues[(int)type];
    }

    public void Log(){
        List<PropertyConf> confs = ConfigManager.propertyConfManager.datas;
        string propertyString = "";
        for (int i = 0; i < confs.Count; i++)
        {
            PropertyConf conf = confs[i];

            propertyString += string.Format(conf.des, propertyValues[conf.id]);
            propertyString += "\n";
        }
        Debug.Log(propertyString);
    }

    public void PropertyAddition(enCharacterProperty target,enCharacterProperty source){

        propertyValues[(int)target] +=
            propertyValues[(int)target] *
            propertyValues[(int)source] *
            ConfigManager.propertyConfManager.dataMap[(int)source].levelrate;
        
    }
}

public class InGameBaseCharacter : InGameBaseObj {

    public enum AnimatorState{
        idle = 0,
        run,
        atk,
        die,
    }

    public GameObject Head;
    public GameObject ArmLeft;
    public GameObject HandLeft;
    public GameObject ArmRight;
    public GameObject HandRight;

    public GameObject Body;
    public GameObject FootLeft;
    public GameObject FootRight;
    public GameObject LegLeft;
    public GameObject LegRight;
    public GameObject Pants;
    public GameObject Weapon;


    public override void Init(int instanceId, int confid, enMSCamp camp)
    {
        base.Init(instanceId,confid,camp);

    }

    public override bool ObjUpdate()
    {
        if (IsDie()) return false;
        base.ObjUpdate();
        return true;
    }

    private void OnDestroy()
    {
    }
}
