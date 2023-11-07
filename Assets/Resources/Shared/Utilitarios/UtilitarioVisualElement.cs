using UnityEngine.UIElements;

public static class UtilitarioVisualElement
{
    public static void TraduzirTextos(this UIDocument ui)
    {
        TraduzirTextosRecursivamente(ui.rootVisualElement);
    }

    private static void TraduzirTextosRecursivamente(VisualElement element)
    {
        if (element.Children() == null) return;

        foreach (VisualElement childElement in element.Children())
        {
            if (childElement is TextElement textElement)
            {
                textElement.text = textElement.text.Traduzir();
            }

            TraduzirTextosRecursivamente(childElement);
        }
    }

}
