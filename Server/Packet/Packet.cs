using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public enum PacketType
{
    QUIT = 0,
    JOIN,
    LOGIN,
    MSG,
    MEMBER,
    POST,
    MYPAGE,
}

[Serializable]
public class Packet
{
    public int Length;
    public int Type;

    public Packet()
    {
        this.Length = 0;
        this.Type = 0;
    }

    public static byte[] Serialize(Object o)
    {
        MemoryStream ms = new MemoryStream(1024 * 512);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(ms, o);
        return ms.ToArray();
    }

    public static Object Desserialize(byte[] bt)
    {
        MemoryStream ms = new MemoryStream(1024 * 512);
        foreach (byte b in bt)
        {
            ms.WriteByte(b);
        }

        ms.Position = 0;
        Object obj = new Object();
        BinaryFormatter bf = new BinaryFormatter();
        try
        {
            obj = bf.Deserialize(ms);
        }
        catch
        {

        }
        ms.Close();
        return obj;
    }
}

[Serializable]
public class Quit : Packet
{
    /* 빈 클래스 */
}

[Serializable]
public class Join : Packet
{
    public string _id;
    public string _password;

    public Join()
    {
        this._id = null;
        this._password = null;
    }
}

[Serializable]
public class Login : Packet
{
    public string _id;
    public string _password;
    public int _postnum;

    public Login()
    {
        this._id = null;
        this._password = null;
        this._postnum = 0;
    }
}

[Serializable]
public class Msg : Packet
{
    public string _text;
    public string _memo;

    public Msg()
    {
        this._text = null;
        this._memo = null;
    }
}

[Serializable]
public class Member : Packet
{
    public string _list;

    public Member()
    {
        this._list = null;
    }
}

[Serializable]
public class Post : Packet
{
    public object _image;
    public string _text;

    public Post()
    {
        this._image = null;
        this._text = null;
    }
}