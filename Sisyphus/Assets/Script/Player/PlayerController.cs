using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //private GearGenerator gearGenerator;测试用，请在Start()里面把另一条注释也去掉
    //目前丝滑移动和冲刺不能同时拥有
    //加速度调整方法：linear drag

    private float inputX, inputY;
    //在移动停止时给予有效输入从而控制idle动画树让玩家显示对应方向动画
    private float stopX, stopY;
    Vector2 movement;

    private readonly int basicDamage = 1;
    private readonly float basicSpeed = 1f;
    private readonly float basicAttackSpd = 1f;
    private readonly float basicRange = 1;
    public int Damage => GetComponent<GearSlot>().damageBonus + basicDamage;
    public double ExtraArmor { get { GetComponent<GearSlot>().RefreshPropertyPanel(); return GetComponent<GearSlot>().armorBonus; } }
    public float MoveSpeed => 25f * (GetComponent<GearSlot>().moveSpdBonus + basicSpeed);
    public float ExtraBattery { get { GetComponent<GearSlot>().RefreshPropertyPanel(); return GetComponent<GearSlot>().batteryBonus; } }
    public double AttackSpd => GetComponent<GearSlot>().attackSpdBonus + basicAttackSpd;
    public float Range => GetComponent<GearSlot>().rangeBonus + basicRange;

    private Vector3 offset; //2.5D

    [Header("Weapon")]
    public GameObject[] guns;
    private int gunNum;

    [Header("Dash")]
    public float dashTime;
    private float dashTimeLeft;//the dash time
    private float lastDash = -10f;//the last time player dashed
    public float dashCoolDown;//dash CD
    public float dashSpeed;
    public bool isDashing;

    private Rigidbody2D rb;
    private Animator animator;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        guns[0].SetActive(true); //激活默认枪械

    }
    void Start()
    {
        //gearGenerator = GameObject.FindWithTag(TagName.gearManager).GetComponent<GearGenerator>();测试用
        offset = Camera.main.transform.position - transform.position;
        transform.rotation = Camera.main.transform.rotation;

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        guns[0].SetActive(true); //激活默认枪械
    }
    /*IEnumerator Test()
    {
        Equip(new Armor(1));
        yield return new WaitForSeconds(3);
        GetComponent<Health>().ChangeHealth(-0.75);
        yield return new WaitForSeconds(2);
        RemoveEquipment(0);
        yield return new WaitForSeconds(3);
        Equip(new Armor(1));
        yield return new WaitForSeconds(3);
        GetComponent<Health>().ChangeHealth(-1.75);
        yield return new WaitForSeconds(2);
        RemoveEquipment(0);
    }*/
    // Update is called once per frame
    void Update()
    {

        //weapon
        SwitchGun();

        //2.5D
        Camera.main.transform.position = transform.position + offset;
    }

    private void FixedUpdate()
    {
        //movement
        Movement();

        Dash();
        if (dashTimeLeft <= 0)
        {
            isDashing = false;
        }
        if (isDashing)return;
    }
    /// <summary>
    /// 装备一个零件，如果是替换零件的话，这个方法将返回被替换下来的那个零件
    /// </summary>
    /// <param name="gear">要装备的零件</param>
    /// <param name="slot">要装备到的位置，默认为-1，即自动寻找可装备的位置，如果没有就会自动放入背包</param>
    /// <returns>被替换下来的零件，如果没有则为null</returns>
    public Gear Equip(Gear gear, int slot = -1)
    {
        Gear[] slots = GetComponent<GearSlot>().Gears;
        if (slot > -1 && slot < 5)
        {
            //替换
            Gear oldGear = slots[slot];
            slots[slot] = gear;
            GetComponent<GearSlot>().RefreshPropertyPanel();
            gear.EquipEvent(this);
            return oldGear;
        }
        else
        {
            //自动装备
            bool canEquip = false;
            for (int i = 0; i < slots.Length; i++)
                if (slots[i] == null)
                {
                    slots[i] = gear;
                    canEquip = true;
                    GetComponent<GearSlot>().RefreshPropertyPanel();
                    gear.EquipEvent(this);
                    break;
                }
            if (!canEquip)
            {
                //如果没有空位就会自动放进背包
            }
            return null;
        }
    }
    /// <summary>
    /// 卸下一个零件，返回被卸下来的那个零件
    /// </summary>
    /// <param name="slot">要卸下的零件的位置</param>
    /// <returns>被卸下的零件</returns>
    public Gear RemoveEquipment(Gear gear)
    {
        int i = 0;
        foreach (Gear g in GetComponent<GearSlot>().Gears)
        {
            if (gear == g)
                GetComponent<GearSlot>().Gears[i] = null;
            else
                i++;
        }
        GetComponent<GearSlot>().RefreshPropertyPanel();
        gear.RemoveEvent(this);
        return gear;
    }
    void Movement()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");
        Vector2 input = new Vector2(inputX, inputY).normalized;
        Vector2 movement = input; //dash补丁
                                  //rb.velocity = input * moveSpeed;
                                  //rb.drag = 100f;
        rb.AddForce(input * MoveSpeed);


        if (input != Vector2.zero)
        {
            animator.SetFloat("isMoving", 1);
            #region 前后左右判定(秋辰写的)
            if (inputX > 0) { animator.SetBool("left", false); }
            if (inputX < 0) { animator.SetBool("left", true); }
            if (inputY > 0) { animator.SetBool("back", true); guns[gunNum].GetComponent<SpriteRenderer>().sortingOrder = 1; }
            if (inputY < 0) { animator.SetBool("back", false); guns[gunNum].GetComponent<SpriteRenderer>().sortingOrder = 2; }
            #endregion
            stopX = inputX;
            stopY = inputY;
        }
        else
        {
            animator.SetFloat("isMoving", 0);
        }
        //animator.SetFloat("InputX", stopX);
        //animator.SetFloat("InputY", stopY);


        //dash
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (Time.time >= (lastDash + dashCoolDown))
            {
                ReadyToDash();
            }
        }
    }

    void ReadyToDash()
    {
        isDashing = true;
        dashTimeLeft = dashTime;
        lastDash = Time.time;
    }

    void Dash()
    {
        if (isDashing)
        {
            if (dashTimeLeft > 0)
            {
                //rb.MovePosition(rb.position + dashSpeed * movement * 0.01f);
                rb.AddForce(rb.position + dashSpeed * movement * 0.01f, ForceMode2D.Impulse);
                dashTimeLeft -= Time.deltaTime;
                //ShadowPool.instance.GetFromPool();
            }
        }
    }

    void SwitchGun()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            guns[gunNum].SetActive(false);
            if (--gunNum < 0)
            {
                gunNum = guns.Length - 1;
            }
            guns[gunNum].SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            guns[gunNum].SetActive(false);
            if (++gunNum > guns.Length - 1)
            {
                gunNum = 0;
            }
            guns[gunNum].SetActive(true);
        }
    }
}
