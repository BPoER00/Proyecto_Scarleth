import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import { ValidatePersona } from "@/validations/Persona.Validation.js";
import { ToastContainer, toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

import { usePersona } from "@/context/Persona.Context.js";
import InputText from "../Inputs/InputText";
import InputSelect from "../Inputs/InputSelect";

function PersonaNew() {
  const { direccion, genero, insert, changePage } = usePersona();

  const sleep = (ms) => {
    return new Promise((resolve) => setTimeout(resolve, ms));
  };

  const {
    register,
    handleSubmit,
    formState: { errors },
    control,
  } = useForm({
    resolver: yupResolver(ValidatePersona),
  });

  const onSubmit = async (e) => {
    const res = await insert(e);
    console.log(res);
    if (res.status === 201) {
      toast.success("Revision Realizada Correctamente");
      await sleep(3000);
      changePage(1);
    } else if (res.status === 400 || res.status === 401) {
      toast.warning(`Error ${res.data.message}`);
    } else if (res.status === 500) {
      toast.warning("Error al guardar la persona");
    }
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
                "url('https://cdn-icons-png.flaticon.com/512/3845/3845289.png')",
            }}
          ></div>
          <div className="w-full lg:w-7/12 dark:bg-gray-800 p-5 rounded-lg lg:rounded-l-none">
            <form
              onSubmit={handleSubmit(onSubmit)}
              className="px-8 pt-6 pb-8 mb-4 dark:bg-gray-900 rounded"
            >
              <div className="mb-4">
                <InputText
                  label={"Nombre"}
                  name={"nombre"}
                  type={"text"}
                  placeholder={"Ingrese Nombre..."}
                  register={register}
                  errors={errors.nombre?.message}
                />
              </div>

              <div className="mb-4">
                <InputText
                  label={"CUI"}
                  name={"cui"}
                  type={"text"}
                  placeholder={"Ingrese Cui..."}
                  register={register}
                  errors={errors.cui?.message}
                />
              </div>

              <div className="mb-4">
                <InputText
                  label={"Telefono"}
                  name={"telefono"}
                  type={"text"}
                  placeholder={"Ingrese Telefono..."}
                  register={register}
                  errors={errors.telefono?.message}
                />
              </div>

              <div className="mb-4">
                <InputText
                  label={"Fecha Nacimiento"}
                  name={"fecha_nacimiento"}
                  type={"date"}
                  placeholder={"Ingrese Fecha Nacimiento..."}
                  register={register}
                  errors={errors.fecha_nacimiento?.message}
                />
              </div>

              <div className="mb-4">
                <InputSelect
                  label={"Direccion"}
                  name={"direccion_id"}
                  options={direccion}
                  control={control}
                  placeholder={"Ingrese Direccion..."}
                  errors={errors.direccion_id?.message}
                />
              </div>

              <div className="mb-4">
                <InputSelect
                  label={"Genero"}
                  name={"genero_id"}
                  options={genero}
                  control={control}
                  placeholder={"Ingrese Genero..."}
                  errors={errors.genero_id?.message}
                />
              </div>

              <div className="mb-6 text-center">
                <button
                  className="w-full mt-3 px-4 py-2 font-bold text-white bg-blue-500 rounded-full hover:bg-blue-700 focus:outline-none focus:shadow-outline"
                  type="submit"
                >
                  Registrar Revision
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

export default PersonaNew;
