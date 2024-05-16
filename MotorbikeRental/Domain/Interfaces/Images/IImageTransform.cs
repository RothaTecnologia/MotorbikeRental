namespace MotorbikeRental.Domain.Interfaces.Images
{
    public interface IImageTransform
    {
        void saveCNHImage(byte[] bytesImage, Guid deliverymanID);
    }
}
