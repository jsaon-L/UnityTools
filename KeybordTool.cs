using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class KeybordTool
{
    #region bVk���� ��������

    public const byte vbKeyLButton = 0x1;    // ������
    public const byte vbKeyRButton = 0x2;    // ����Ҽ�
    public const byte vbKeyCancel = 0x3;     // CANCEL ��
    public const byte vbKeyMButton = 0x4;    // ����м�
    public const byte vbKeyBack = 0x8;       // BACKSPACE ��
    public const byte vbKeyTab = 0x9;        // TAB ��
    public const byte vbKeyClear = 0xC;      // CLEAR ��
    public const byte vbKeyReturn = 0xD;     // ENTER ��
    public const byte vbKeyShift = 0x10;     // SHIFT ��
    public const byte vbKeyControl = 0x11;   // CTRL ��
    public const byte vbKeyAlt = 18;         // Alt ��  (����18)
    public const byte vbKeyMenu = 0x12;      // MENU ��
    public const byte vbKeyPause = 0x13;     // PAUSE ��
    public const byte vbKeyCapital = 0x14;   // CAPS LOCK ��
    public const byte vbKeyEscape = 0x1B;    // ESC ��
    public const byte vbKeySpace = 0x20;     // SPACEBAR ��
    public const byte vbKeyPageUp = 0x21;    // PAGE UP ��
    public const byte vbKeyEnd = 0x23;       // End ��
    public const byte vbKeyHome = 0x24;      // HOME ��
    public const byte vbKeyLeft = 0x25;      // LEFT ARROW ��
    public const byte vbKeyUp = 0x26;        // UP ARROW ��
    public const byte vbKeyRight = 0x27;     // RIGHT ARROW ��
    public const byte vbKeyDown = 0x28;      // DOWN ARROW ��
    public const byte vbKeySelect = 0x29;    // Select ��
    public const byte vbKeyPrint = 0x2A;     // PRINT SCREEN ��
    public const byte vbKeyExecute = 0x2B;   // EXECUTE ��
    public const byte vbKeySnapshot = 0x2C;  // SNAPSHOT ��
    public const byte vbKeyDelete = 0x2E;    // Delete ��
    public const byte vbKeyHelp = 0x2F;      // HELP ��
    public const byte vbKeyNumlock = 0x90;   // NUM LOCK ��

    //���ü� ��ĸ��A��Z
    public const byte vbKeyA = 65;
    public const byte vbKeyB = 66;
    public const byte vbKeyC = 67;
    public const byte vbKeyD = 68;
    public const byte vbKeyE = 69;
    public const byte vbKeyF = 70;
    public const byte vbKeyG = 71;
    public const byte vbKeyH = 72;
    public const byte vbKeyI = 73;
    public const byte vbKeyJ = 74;
    public const byte vbKeyK = 75;
    public const byte vbKeyL = 76;
    public const byte vbKeyM = 77;
    public const byte vbKeyN = 78;
    public const byte vbKeyO = 79;
    public const byte vbKeyP = 80;
    public const byte vbKeyQ = 81;
    public const byte vbKeyR = 82;
    public const byte vbKeyS = 83;
    public const byte vbKeyT = 84;
    public const byte vbKeyU = 85;
    public const byte vbKeyV = 86;
    public const byte vbKeyW = 87;
    public const byte vbKeyX = 88;
    public const byte vbKeyY = 89;
    public const byte vbKeyZ = 90;

    //���ּ���0��9
    public const byte vbKey0 = 48;    // 0 ��
    public const byte vbKey1 = 49;    // 1 ��
    public const byte vbKey2 = 50;    // 2 ��
    public const byte vbKey3 = 51;    // 3 ��
    public const byte vbKey4 = 52;    // 4 ��
    public const byte vbKey5 = 53;    // 5 ��
    public const byte vbKey6 = 54;    // 6 ��
    public const byte vbKey7 = 55;    // 7 ��
    public const byte vbKey8 = 56;    // 8 ��
    public const byte vbKey9 = 57;    // 9 ��


    public const byte vbKeyNumpad0 = 0x60;    //0 ��
    public const byte vbKeyNumpad1 = 0x61;    //1 ��
    public const byte vbKeyNumpad2 = 0x62;    //2 ��
    public const byte vbKeyNumpad3 = 0x63;    //3 ��
    public const byte vbKeyNumpad4 = 0x64;    //4 ��
    public const byte vbKeyNumpad5 = 0x65;    //5 ��
    public const byte vbKeyNumpad6 = 0x66;    //6 ��
    public const byte vbKeyNumpad7 = 0x67;    //7 ��
    public const byte vbKeyNumpad8 = 0x68;    //8 ��
    public const byte vbKeyNumpad9 = 0x69;    //9 ��
    public const byte vbKeyMultiply = 0x6A;   // MULTIPLICATIONSIGN(*)��
    public const byte vbKeyAdd = 0x6B;        // PLUS SIGN(+) ��
    public const byte vbKeySeparator = 0x6C;  // ENTER ��
    public const byte vbKeySubtract = 0x6D;   // MINUS SIGN(-) ��
    public const byte vbKeyDecimal = 0x6E;    // DECIMAL POINT(.) ��
    public const byte vbKeyDivide = 0x6F;     // DIVISION SIGN(/) ��


    //F1��F12����
    public const byte vbKeyF1 = 0x70;   //F1 ��
    public const byte vbKeyF2 = 0x71;   //F2 ��
    public const byte vbKeyF3 = 0x72;   //F3 ��
    public const byte vbKeyF4 = 0x73;   //F4 ��
    public const byte vbKeyF5 = 0x74;   //F5 ��
    public const byte vbKeyF6 = 0x75;   //F6 ��
    public const byte vbKeyF7 = 0x76;   //F7 ��
    public const byte vbKeyF8 = 0x77;   //F8 ��
    public const byte vbKeyF9 = 0x78;   //F9 ��
    public const byte vbKeyF10 = 0x79;  //F10 ��
    public const byte vbKeyF11 = 0x7A;  //F11 ��
    public const byte vbKeyF12 = 0x7B;  //F12 ��

    #endregion

    #region ����win32api����

    /// <summary>
    /// ����ģ����̵ķ���
    /// </summary>
    /// <param name="bVk" >�����������ֵ</param>
    /// <param name= "bScan" >ɨ���룬һ�㲻�����ã���0�������</param>
    /// <param name= "dwFlags" >ѡ���־��0����ʾ���£�2����ʾ�ɿ�</param>
    /// <param name= "dwExtraInfo">һ������Ϊ0</param>
    [DllImport("user32.dll")]
    public static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

    #endregion


    public static void Shift_B()
    {
        //ģ�ⰴ��shift��
        keybd_event(vbKeyShift, 0, 0, 0);
        //ģ�ⰴ��A��
        keybd_event(vbKeyB, 0, 0, 0);


        //ģ���ɿ�A��
        keybd_event(vbKeyB, 0, 2, 0);
        //�ɿ�����shift
        keybd_event(vbKeyShift, 0, 2, 0);

    }

    /// <summary>
    /// shift + ��ϼ�
    /// �� vbKeyA
    /// </summary>
    public static void Shift_Comb(byte vb)
    {
        //ģ�ⰴ��shift��
        keybd_event(vbKeyShift, 0, 0, 0);
        //ģ�ⰴ��A��
        keybd_event(vb, 0, 0, 0);


        //ģ���ɿ�A��
        keybd_event(vb, 0, 2, 0);
        //�ɿ�����shift
        keybd_event(vbKeyShift, 0, 2, 0);

    }

}
