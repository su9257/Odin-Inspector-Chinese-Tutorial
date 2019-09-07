using Sirenix.OdinInspector;
using Sirenix.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableMatrixAttributeExample : MonoBehaviour
{
    //[TableMatrix(HorizontalTitle = "Square Celled Matrix", SquareCells = true)]
    //public Texture2D[,] SquareCelledMatrix = new Texture2D[8, 4]
    //{
    //{ ExampleHelper.GetTexture(), null, null, null },
    //{ null, ExampleHelper.GetTexture(), null, null },
    //{ null, null, ExampleHelper.GetTexture(), null },
    //{ null, null, null, ExampleHelper.GetTexture() },
    //{ ExampleHelper.GetTexture(), null, null, null },
    //{ null, ExampleHelper.GetTexture(), null, null },
    //{ null, null, ExampleHelper.GetTexture(), null },
    //{ null, null, null, ExampleHelper.GetTexture() },
    //};

    //[TableMatrix(SquareCells = true)]
    //public Mesh[,] PrefabMatrix = new Mesh[8, 4]
    //{
    //{ ExampleHelper.GetMesh(), null, null, null },
    //{ null, ExampleHelper.GetMesh(), null, null },
    //{ null, null, ExampleHelper.GetMesh(), null },
    //{ null, null, null, ExampleHelper.GetMesh() },
    //{ null, null, null, ExampleHelper.GetMesh() },
    //{ null, null, ExampleHelper.GetMesh(), null },
    //{ null, ExampleHelper.GetMesh(), null, null },
    //{ ExampleHelper.GetMesh(), null, null, null },
    //};

    [TableMatrix(HorizontalTitle = "Read Only Matrix", IsReadOnly = true)]
    public int[,] ReadOnlyMatrix = new int[5, 5];

    [TableMatrix(HorizontalTitle = "X axis", VerticalTitle = "Y axis")]
    public InfoMessageType[,] LabledMatrix = new InfoMessageType[6, 6];


    [TableMatrix(HorizontalTitle = "Custom Cell Drawing", DrawElementMethod = "DrawColoredEnumElement", ResizableColumns = false, RowHeight = 16)]
    public bool[,] CustomCellDrawing;

    [ShowInInspector, DoNotDrawAsReference]
    [TableMatrix(HorizontalTitle = "Transposed Custom Cell Drawing", DrawElementMethod = "DrawColoredEnumElement", ResizableColumns = false, RowHeight = 16, Transpose = true)]
    public bool[,] Transposed { get { return CustomCellDrawing; } set { CustomCellDrawing = value; } }

    private static bool DrawColoredEnumElement(Rect rect, bool value)
    {
        if (Event.current.type == EventType.MouseDown && rect.Contains(Event.current.mousePosition))
        {
            value = !value;
            GUI.changed = true;
            Event.current.Use();
        }

        UnityEditor.EditorGUI.DrawRect(rect.Padding(1), value ? new Color(0.1f, 0.8f, 0.2f) : new Color(0, 0, 0, 0.5f));

        return value;
    }

    //public TransposeTableMatrixExample()
    //{
    //    // =)
    //    this.CustomCellDrawing = new bool[15, 15];
    //    this.CustomCellDrawing[6, 5] = true;
    //    this.CustomCellDrawing[6, 6] = true;
    //    this.CustomCellDrawing[6, 7] = true;
    //    this.CustomCellDrawing[8, 5] = true;
    //    this.CustomCellDrawing[8, 6] = true;
    //    this.CustomCellDrawing[8, 7] = true;
    //    this.CustomCellDrawing[5, 9] = true;
    //    this.CustomCellDrawing[5, 10] = true;
    //    this.CustomCellDrawing[9, 9] = true;
    //    this.CustomCellDrawing[9, 10] = true;
    //    this.CustomCellDrawing[6, 11] = true;
    //    this.CustomCellDrawing[7, 11] = true;
    //    this.CustomCellDrawing[8, 11] = true;
    //}
}
