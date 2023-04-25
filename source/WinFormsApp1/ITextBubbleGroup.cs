namespace WinFormsWithAspose
{
    public interface ITextBubbleGroup : IDiagramGroup
    {
        List<ITextBubble> TextBubbles { get; }
        public IDiagramGroup SetDimensions(double width, double height);
    }
}