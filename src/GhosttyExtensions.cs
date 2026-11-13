using GhosttyVT.Interop;

namespace GhosttyVT;

public static class GhosttyExtensions {
    public static void ThrowIfError(this GhosttyResult result, string error = "") {
        switch (result) {
            case GhosttyResult.SUCCESS:
                break;
            case GhosttyResult.OUT_OF_MEMORY:
                throw new OutOfMemoryException(error);
            case GhosttyResult.INVALID_VALUE:
                throw new ArgumentException(error);
            case GhosttyResult.OUT_OF_SPACE:
                throw new IOException("Operation failed because the provided buffer was too small", new Exception(error));
            case GhosttyResult.NO_VALUE:
                throw new ArgumentException("The requested value has no value", new ArgumentException(error));
            case GhosttyResult.IO_ERROR:
                throw new IOException(error);
            case GhosttyResult.LIMIT_EXCEEDED:
                throw new Exception(error); // TODO: new GhosttyLimitExceededException(error);
            case GhosttyResult.REJECTED:
                throw new Exception(error); // TODO: new GhosttyRejectedException(error);
            case GhosttyResult.UNSUPPORTED:
                throw new NotSupportedException(error);
            default:
                throw new Exception($"Unknown error, Code {((uint)result):x}");
        }
    }
}