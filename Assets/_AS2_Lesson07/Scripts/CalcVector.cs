using UnityEngine;

public class CalcVector : MonoBehaviour
{
    // === フィールド
    public Vector3 A;
    public Vector3 B;
    public Vector3 C;

    void Start()
    {
        
    }


    void Update()
    {
        // 十字線（あると見やすい）
        Debug.DrawRay(Vector3.right * -50, Vector3.right * 100, Color.black);
        Debug.DrawRay(Vector3.up * -50, Vector3.up * 100, Color.black);

        C = CrossMultiply(A, B);
        float dot = DotMultiply(A, B);
    }

    
    /// <summary>
    /// 足し算
    /// ※ a に b を合わせた目的地
    /// </summary>
    private Vector3 Additive(Vector3 a, Vector3 b)
    {
        // ベクトルの可視化
        // Debug.DrawRay((Vector3)開始座標, (Vector3)方向, (Color)描画色, (float)描画時間, (bool)深度設定)
        Debug.DrawRay(Vector3.zero, a, Color.red, 0, false);
        Debug.DrawRay(a, b, Color.blue, 0, false);
        Debug.DrawRay(Vector3.zero, a + b, Color.green, 0, false);


        // return new Vector3(a.x + b.x, a.y + b.y, a.z + b.z);
        return a + b;
    }


    /// <summary>
    /// 引き算
    /// ※ a と b がどのぐらい離れているか（差分）
    /// </summary>
    private Vector3 Subtract(Vector3 a, Vector3 b)
    {
        // ベクトルの可視化
        Debug.DrawRay(Vector3.zero, a, Color.red, 0, false);
        Debug.DrawRay(Vector3.zero, b, Color.blue, 0, false);
        Debug.DrawRay(b, a - b, Color.green, 0, false);

        return a - b;
    }


    /// <summary>
    /// ベクトルの掛け算(内積)
    /// </summary>
    /// <returns></returns>
    private float DotMultiply(Vector3 a, Vector3 b)
    {
        Debug.DrawRay(Vector3.zero, a, Color.red, 0, false);
        Debug.DrawRay(Vector3.zero, b, Color.blue, 0, false);

        //float c = (a.x * b.x) + (a.y * b.y) + (a.z * b.z);
        float c = Vector3.Dot(a, b);
        Debug.Log($"{a}と{b}の内積 = {c}");

        return c;
    }


    /// <summary>
    /// ベクトル同士の掛け算（外積）
    /// ※ AとBに垂直なベクトル
    /// </summary>
    public Vector3 CrossMultiply(Vector3 a, Vector3 b)
    {
        Vector3 c = Vector3.zero;

        /*
        c.x = (a.y * b.z) - (a.z * b.y);
        c.y = (a.z * b.x) - (a.x * b.z);
        c.z = (a.x * b.y) - (a.y * b.x);
        */

        c = Vector3.Cross(a, b);

        // ベクトルの可視化
        Debug.DrawRay(Vector3.zero, a, Color.red, 0, false);
        Debug.DrawRay(Vector3.zero, b, Color.blue, 0, false);
        Debug.DrawRay(Vector3.zero, c.normalized, Color.green, 0, false);

        return c.normalized;
    }

    /// <summary>
    /// ベクトルの掛け算（スカラー倍）
    /// ※ ベクトルの方向を変えずに力を倍にすることができる
    /// </summary>
    private Vector3 ScalarMultiply(Vector3 a, float b)
    {
        // ベクトルの可視化
        Debug.DrawRay(Vector3.zero, a * b, Color.green, 0, false);
        Debug.DrawRay(Vector3.zero, a, Color.red, 0, false);

        return a * b;
    }
}
