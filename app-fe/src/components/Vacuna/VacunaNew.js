import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import { ValidateVacuna } from "@/validations/Vacuna.Validation.js";
import { ToastContainer, toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

import { useVacuna } from "@/context/Vacuna.Context";
import InputText from "../Inputs/InputText";

function VacunaNew() {
  const { insert, changePage } = useVacuna();

  const sleep = (ms) => {
    return new Promise((resolve) => setTimeout(resolve, ms));
  };

  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm({
    resolver: yupResolver(ValidateVacuna),
  });

  const onSubmit = async (e) => {
    const res = await insert(e);
    if (res.status === 201) {
      toast.success("Se Ingreso la vacuna correctamente");
      await sleep(3000);
      changePage(1);
    } else if (res.status === 400 || res.status === 401) {
      toast.warning(`Error ${res.data.message}`);
    } else if (res.status === 500) {
      toast.warning("Error al guardar la vacuna");
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
                "url('https://img.freepik.com/iconos-gratis/vacuna_318-819662.jpg?w=2000')",
            }}
          ></div>
          <div className="w-full lg:w-7/12 dark:bg-gray-800 p-5 rounded-lg lg:rounded-l-none">
            <form
              onSubmit={handleSubmit(onSubmit)}
              className="px-8 pt-6 pb-8 mb-4 dark:bg-gray-900 rounded"
            >
              <div className="mb-4">
                <InputText
                  label={"Descripcion"}
                  name={"descripcion"}
                  type={"text"}
                  placeholder={"Ingrese Descripcion..."}
                  register={register}
                  errors={errors.descripcion?.message}
                />
              </div>

              <div className="mb-4">
                <InputText
                  label={"Cantidad"}
                  name={"cantidad"}
                  type={"text"}
                  placeholder={"Ingrese Cantidad..."}
                  register={register}
                  errors={errors.cantidad?.message}
                />
              </div>

              <div className="mb-4">
                <InputText
                  label={"Fecha vencimiento"}
                  name={"fecha_vencimiento"}
                  type={"date"}
                  placeholder={"Ingrese descripcion..."}
                  register={register}
                  errors={errors.descripcion?.message}
                />
              </div>

              <div className="mb-4">
                <InputText
                  label={"Total Dosis"}
                  name={"dosis"}
                  type={"text"}
                  placeholder={"Ingrese dosis..."}
                  register={register}
                  errors={errors.dosis?.message}
                />
              </div>

              <div className="mb-4">
                <InputText
                  label={"Nombre Vacuna"}
                  name={"nombre"}
                  type={"text"}
                  placeholder={"Ingrese estatus..."}
                  register={register}
                  errors={errors.nombre?.message}
                />
              </div>

              <div className="mb-4">
                <InputText
                  label={"Cubre"}
                  name={"cubre"}
                  type={"text"}
                  placeholder={"Ingrese Cubre..."}
                  register={register}
                  errors={errors.cubre?.message}
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

export default VacunaNew;
