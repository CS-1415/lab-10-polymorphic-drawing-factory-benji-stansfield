namespace Lab10;

public interface IGraphic2DFactory
{
    public readonly string Name;

    public IGraphic2D Create();
}