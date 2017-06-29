{-# LANGUAGE ForeignFunctionInterface #-}

module Hello () where

import Foreign.C.Types

func :: (Num a) => a -> a
func n = n*n

cFunc :: CInt -> CInt
cFunc (CInt n) = CInt (func n)

foreign export ccall cFunc :: CInt -> CInt