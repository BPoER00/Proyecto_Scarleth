import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import { ValidateUsuario } from "@/validations/Usuario.Validation.js";
import { ToastContainer, toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

import { useUsuario } from "@/context/Usuario.Context.js";
import InputText from "../Inputs/InputText";
import InputSelect from "../Inputs/InputSelect";

function CargoNew() {
  const { rol, persona, insert, changePage } = useUsuario();

  const sleep = (ms) => {
    return new Promise((resolve) => setTimeout(resolve, ms));
  };

  const {
    register,
    handleSubmit,
    formState: { errors },
    control,
  } = useForm({
    resolver: yupResolver(ValidateUsuario),
  });

  const onSubmit = async (e) => {
    console.log(e);
    // const res = await insert(e);
    // if (res.status === 204) {
    //   toast.success("Revision Realizada Correctamente");
    //   await sleep(3000);
    //   changePage(1);
    // } else if (res.status === 400 || res.status === 401) {
    //   toast.warning(`Error ${res.data.message}`);
    // }
  };

  return (
    <div className="container mx-auto">
      <ToastContainer />
      <div className="flex justify-center px-6 my-12">
        <div className="w-full xl:w-4/4 lg:w-11/12 flex">
          <div
            className="w-full h-auto bg-cyan-100 hidden lg:block lg:w-5/12 bg-cover rounded-l-lg"
            style={{
              backgroundImage:
                "url('https://cdn-icons-png.flaticon.com/512/306/306232.png')",
            }}
          ></div>
          <div className="w-full lg:w-7/12 dark:bg-gray-800 p-5 rounded-lg lg:rounded-l-none">
            <form
              onSubmit={handleSubmit(onSubmit)}
              className="px-8 pt-6 pb-8 mb-4 dark:bg-gray-900 rounded"
            >
              <div className="mb-4">
                <InputSelect
                  label={"Persona"}
                  name={"persona_id"}
                  options={persona}
                  control={control}
                  placeholder={"Ingrese Persona..."}
                  errors={errors.persona_id?.message}
                />
              </div>

              <div className="mb-4">
                <InputText
                  label={"Nombre Usurio"}
                  name={"nombre_usuario"}
                  type={"text"}
                  placeholder={"Ingrese Nombre Usuario..."}
                  register={register}
                  errors={errors.descripcion?.message}
                />
              </div>

              <div className="mb-4">
                <InputText
                  label={"Correo"}
                  name={"correo"}
                  type={"email"}
                  placeholder={"Ingrese Email..."}
                  register={register}
                  errors={errors.correo?.message}
                />
              </div>

              <div className="mb-4">
                <InputText
                  label={"Password"}
                  name={"password"}
                  type={"password"}
                  placeholder={"Ingrese Password..."}
                  register={register}
                  errors={errors.status?.message}
                />
              </div>

              <div className="mb-4">
                <InputText
                  label={"Password Confirm"}
                  name={"password_confirm"}
                  type={"password"}
                  placeholder={"Ingrese Password Confirm..."}
                  register={register}
                  errors={errors.password_confirm?.message}
                />
              </div>

              <div className="mb-4">
                <InputSelect
                  label={"Rol"}
                  name={"rol_id"}
                  options={rol}
                  control={control}
                  placeholder={"Ingrese Rol..."}
                  errors={errors.rol?.message}
                />
              </div>

              <div className="mb-6 text-center">
                <button
                  className="w-full mt-3 px-4 py-2 font-bold text-white bg-blue-500 rounded-full hover:bg-blue-700 focus:outline-none focus:shadow-outline"
                  type="submit"
                >
                  Registrar Usuario
                </button>
              </div>
              <hr className="mb-6 border-t" />
            </form>
          </div>
        </div>
      </div>
    </div>
  );
}

export default CargoNew;
