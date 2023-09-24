import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import { ValidateAsignacion } from "@/validations/Asignacion.Validation.js";
import { ToastContainer, toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

import { useAsignacion } from "@/context/Asignacion.Context.js";
import InputText from "../Inputs/InputText";
import InputSelect from "../Inputs/InputSelect";

function AsignacionNew() {
  const { persona, cargo, insert, changePage } = useAsignacion();

  const sleep = (ms) => {
    return new Promise((resolve) => setTimeout(resolve, ms));
  };

  const {
    register,
    handleSubmit,
    formState: { errors },
    control,
  } = useForm({
    resolver: yupResolver(ValidateAsignacion),
  });

  const onSubmit = async (e) => {
    const res = await insert(e);
    if (res.status === 204) {
      toast.success("Revision Realizada Correctamente");
      await sleep(3000);
      changePage(1);
    } else if (res.status === 400 || res.status === 401) {
      toast.warning(`Error ${res.data.message}`);
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
                "url('https://cdn-icons-png.flaticon.com/512/5387/5387223.png')",
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
                <InputSelect
                  label={"Cargo"}
                  name={"cargo_id"}
                  options={cargo}
                  control={control}
                  placeholder={"Ingrese Cargo..."}
                  errors={errors.cargo_id?.message}
                />
              </div>
              <div className="mb-4">
                <InputText
                  label={"Numero Colegiado"}
                  name={"numero_colegiado"}
                  type={"text"}
                  placeholder={"Ingrese Numero Colegiado..."}
                  register={register}
                  errors={errors.numero_colegiado?.message}
                />
              </div>

              <div className="mb-6 text-center">
                <button
                  className="w-full mt-3 px-4 py-2 font-bold text-white bg-blue-500 rounded-full hover:bg-blue-700 focus:outline-none focus:shadow-outline"
                  type="submit"
                >
                  Registrar Asignacion
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

export default AsignacionNew;