// <auto-generated/> by Diplomat

#pragma warning disable 0105
using System;
using System.Runtime.InteropServices;

using Devolutions.Picky.Diplomat;
#pragma warning restore 0105

namespace Devolutions.Picky;

#nullable enable

public partial class JwtSigBuilder: IDisposable
{
    private unsafe Raw.JwtSigBuilder* _inner;

    public JwsAlg Algorithm
    {
        set
        {
            SetAlgorithm(value);
        }
    }

    public string Claims
    {
        set
        {
            SetClaims(value);
        }
    }

    public string ContentType
    {
        set
        {
            SetContentType(value);
        }
    }

    /// <summary>
    /// Creates a managed <c>JwtSigBuilder</c> from a raw handle.
    /// </summary>
    /// <remarks>
    /// Safety: you should not build two managed objects using the same raw handle (may causes use-after-free and double-free).
    /// <br/>
    /// This constructor assumes the raw struct is allocated on Rust side.
    /// If implemented, the custom Drop implementation on Rust side WILL run on destruction.
    /// </remarks>
    public unsafe JwtSigBuilder(Raw.JwtSigBuilder* handle)
    {
        _inner = handle;
    }

    /// <returns>
    /// A <c>JwtSigBuilder</c> allocated on Rust side.
    /// </returns>
    public static JwtSigBuilder Init()
    {
        unsafe
        {
            Raw.JwtSigBuilder* retVal = Raw.JwtSigBuilder.Init();
            return new JwtSigBuilder(retVal);
        }
    }

    public void SetAlgorithm(JwsAlg alg)
    {
        unsafe
        {
            if (_inner == null)
            {
                throw new ObjectDisposedException("JwtSigBuilder");
            }
            Raw.JwsAlg algRaw;
            algRaw = (Raw.JwsAlg)alg;
            Raw.JwtSigBuilder.SetAlgorithm(_inner, algRaw);
        }
    }

    public void SetContentType(string cty)
    {
        unsafe
        {
            if (_inner == null)
            {
                throw new ObjectDisposedException("JwtSigBuilder");
            }
            byte[] ctyBuf = DiplomatUtils.StringToUtf8(cty);
            nuint ctyBufLength = (nuint)ctyBuf.Length;
            fixed (byte* ctyBufPtr = ctyBuf)
            {
                Raw.JwtSigBuilder.SetContentType(_inner, ctyBufPtr, ctyBufLength);
            }
        }
    }

    /// <summary>
    /// Claims should be a valid JSON payload.
    /// </summary>
    public void SetClaims(string claims)
    {
        unsafe
        {
            if (_inner == null)
            {
                throw new ObjectDisposedException("JwtSigBuilder");
            }
            byte[] claimsBuf = DiplomatUtils.StringToUtf8(claims);
            nuint claimsBufLength = (nuint)claimsBuf.Length;
            fixed (byte* claimsBufPtr = claimsBuf)
            {
                Raw.JwtSigBuilder.SetClaims(_inner, claimsBufPtr, claimsBufLength);
            }
        }
    }

    /// <exception cref="PickyException"></exception>
    /// <returns>
    /// A <c>JwtSig</c> allocated on Rust side.
    /// </returns>
    public JwtSig Build()
    {
        unsafe
        {
            if (_inner == null)
            {
                throw new ObjectDisposedException("JwtSigBuilder");
            }
            IntPtr resultPtr = Raw.JwtSigBuilder.Build(_inner);
            Raw.JwtFfiResultBoxJwtSigBoxPickyError result = Marshal.PtrToStructure<Raw.JwtFfiResultBoxJwtSigBoxPickyError>(resultPtr);
            Raw.JwtFfiResultBoxJwtSigBoxPickyError.Destroy(resultPtr);
            if (!result.isOk)
            {
                throw new PickyException(new PickyError(result.Err));
            }
            Raw.JwtSig* retVal = result.Ok;
            return new JwtSig(retVal);
        }
    }

    /// <summary>
    /// Returns the underlying raw handle.
    /// </summary>
    public unsafe Raw.JwtSigBuilder* AsFFI()
    {
        return _inner;
    }

    /// <summary>
    /// Destroys the underlying object immediately.
    /// </summary>
    public void Dispose()
    {
        unsafe
        {
            if (_inner == null)
            {
                return;
            }

            Raw.JwtSigBuilder.Destroy(_inner);
            _inner = null;

            GC.SuppressFinalize(this);
        }
    }

    ~JwtSigBuilder()
    {
        Dispose();
    }
}