
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardcodedScaling : MonoBehaviour
{
    public Vector3 minScale;
    public Vector3 maxScale;
    public bool repeatable;
    public float speed = 0.05f;
    public float duration = 100f;
    float[] array = new float[] { 25.00110179855626f, 46.03880355507267f, 47.734539336148536f, 28.529257484377332f, 6.0802055796598955f, 1.0269383821745024f, 18.01540648896397f, 41.426490640442516f, 49.73614804704442f, 35.304517995108036f, 11.399974621881585f, 0.00024476078660786577f, 11.58618765328988f, 35.50574066299101f, 49.76737714831092f, 41.25901428475952f, 17.803201662097244f, 0.9651052321875824f, 6.225593186891746f, 28.748197183049857f, 47.82573895531576f, 45.918414599531395f, 24.779809321196783f, 3.8446593341368547f, 2.3606449836244283f, 21.692162223589193f, 44.06590323435553f, 48.91155373217297f, 31.774044982162362f, 8.409523507700984f, 0.29922258673939756f, 14.899715505462325f, 38.787376384677266f, 50.0f, 38.22875189109583f, 14.29606330250974f, 0.20553773304789538f, 8.911939424170422f, 32.41064281202872f, 49.09704835692108f, 43.6297517631602f, 21.035360303328567f, 2.087053276437892f, 4.205816775345289f, 25.443669427511665f, 46.27462744783163f, 47.546804087656135f, 28.090566026244773f, 5.79388881167993f, 1.1562346302601554f, 18.441441364320923f, 41.757569656094745f, 49.667878663412694f, 34.899666778314916f, 11.030759900588818f, 0.006120944750035133f, 11.96175210441524f, 35.90570123925361f, 49.824011944206376f, 40.920253530573085f, 17.38050043365411f, 0.8470930813920968f, 6.52076994533149f, 29.185178690824905f, 48.00276643191665f, 45.67272977220105f, 24.337293694533116f, 3.6121597128785456f, 2.551920438133708f, 22.131354978813913f, 44.34922152019239f, 48.77851599419986f, 31.346965535771158f, 8.08105720719112f, 0.3713598658292871f, 15.306133666310673f, 39.15441646013339f, 49.9902070434244f, 37.85112949927703f, 13.897795750858739f, 0.15279038347219961f, 9.253207938873866f, 32.832166463576044f, 49.21128026612132f, 43.3316676265923f, 20.599017298692353f, 1.9136231583725891f, 4.454750395849945f, 25.8860983753554f, 46.50378457178608f, 47.35200340278996f, 27.650906375443963f, 5.51359123396568f, 1.293003457662379f, 18.869531955273267f, 42.08339749032739f, 49.59187913911365f, 34.49171352481504f, 10.665923247237505f, 0.019830023909153675f, 12.341402860624067f };

    IEnumerator Start()
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (i == 0)
            {
                yield return Repeat(new Vector3(0, 0, 0), new Vector3(array[i], array[i], array[i]), duration);
            }
            else if (i == array.Length - 1)
            {
                yield return Repeat(new Vector3(array[i], array[i], array[i]), new Vector3(0, 0, 0), duration);
            }
            else
            {
                yield return Repeat(new Vector3(array[i - 1], array[i - 1], array[i - 1]), new Vector3(array[i], array[i], array[i]), duration);
            }
        }
    }


    IEnumerator Repeat(Vector3 a, Vector3 b, float time)
    {
        float i = 0.0f;
        float rate = (1.0f/ time) * speed;

        while(i < 1.0f)
        {
          i += Time.deltaTime * rate;
          transform.localScale = Vector3.Lerp(a, b, i);
          yield return null;
        }
    }
}
