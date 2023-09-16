"use client";
import { useState, useEffect } from "react";
import { useForm } from "react-hook-form";
import { useLogin } from "@/context/Login.Context.js";
import { useRouter } from "next/navigation";
import { ValidateUsuario } from "@/validations/Login.Validation.js";
import { yupResolver } from "@hookform/resolvers/yup";
import { ToastContainer, toast } from "react-toastify";
import ProgresBar from "../Inputs/ProgresBar.js";
import "react-toastify/dist/ReactToastify.css";

function LoginForm() {
  const router = useRouter();

  const { Login } = useLogin();

  const [loading, setLoading] = useState(true);

  useEffect(() => {
    setLoading(false);
  }, []);

  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm({
    resolver: yupResolver(ValidateUsuario),
  });

  const onSubmit = async (e) => {
    console.log(e);
    const res = await Login(e);
    console.log(res.status);
    if (res.status === 200) {
      toast.success(res.data.message);
      // router.push("/Dashboard");
      // setLoading(true);
    } else if (res.status === 400 || res.status === 401 ) {
      toast.warning(`Error al ingresar ${res.data.message}`);
    }
  };

  return (
    <>
      {loading ? (
        <ProgresBar />
      ) : (
        <div
          className="flex h-screen w-full items-center justify-center bg-gray-900 bg-cover bg-no-repeat"
          style={{
            background: "#a7d0ea",
          }}
        >
          <ToastContainer />
          <div className="rounded-xl bg-gray-800 bg-opacity-50 px-16 py-10 shadow-lg backdrop-blur-md max-w-sm">
            <div className="text-white items-center">
              <div className="mb-8 flex flex-col items-center">
                <img src="vacunaT.png" width="150" />
                <h1 className="mb-2 mt-3 text-2xl">Vacuna T</h1>
                <span className="text-gray-300">Datos De Inicio De Sesion</span>
              </div>
              <form
                onSubmit={handleSubmit(onSubmit)}
                className="items-center flex flex-col"
              >
                <div className="mb-4 text-lg items-center">
                  <input
                    className="rounded-2xl border-none bg-white bg-opacity-90 px-6 py-2 text-center text-black placeholder-slate-400 shadow-lg outline-none backdrop-blur-md"
                    type="text"
                    placeholder="Usuario"
                    {...register("nombre_usuario")}
                  />
                  <span className="text-red-500 text-center">
                    {errors.nombre_usuario?.message}
                  </span>
                </div>

                <div className="mb-4 text-lg">
                  <input
                    className="rounded-2xl border-none bg-white bg-opacity-90 px-6 py-2 text-center text-black placeholder-slate-400 shadow-lg outline-none backdrop-blur-md"
                    type="Password"
                    placeholder="contraseña"
                    {...register("password")}
                  />
                  <span className="text-red-500">
                    {errors.password?.message}
                  </span>
                </div>
                <div className="mt-8 flex justify-center text-lg text-black">
                  <button
                    type="submit"
                    style={{ background: "#a7d0ea" }}
                    className="rounded-3xl bg-opacity-50 px-10 py-2 text-black shadow-xl backdrop-blur-md transition-colors duration-300"
                  >
                    INICIAR SESION
                  </button>
                </div>
              </form>
            </div>
          </div>
        </div>
      )}
      ;
    </>
  );
}

export default LoginForm;
