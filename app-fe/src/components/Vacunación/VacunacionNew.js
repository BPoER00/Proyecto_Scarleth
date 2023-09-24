import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import { ValidateVacuna } from "@/validations/Vacunacion.Validation.js";
import { ToastContainer, toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

import { useVacunacion } from "@/context/Vacunacion.Context";
import InputText from "../Inputs/InputText";
import InputSelect from "../Inputs/InputSelect";

function VacunacionNew() {
  const { asignacion, vacuna, persona, insert, changePage } = useVacunacion();

  const sleep = (ms) => {
    return new Promise((resolve) => setTimeout(resolve, ms));
  };

  const {
    register,
    handleSubmit,
    formState: { errors },
    control,
  } = useForm({
    resolver: yupResolver(ValidateVacuna),
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
                "url('https://static.vecteezy.com/system/resources/previews/004/698/261/non_2x/female-doctor-injecting-vaccine-to-student-boy-healthcare-and-medical-concept-drawn-cartoon-art-illustration-vector.jpg')",
            }}
          ></div>
          <div className="w-full lg:w-7/12 dark:bg-gray-800 p-5 rounded-lg lg:rounded-l-none">
            <h3 className="pt-4 text-2xl text-center">Revision!</h3>
            <form
              onSubmit={handleSubmit(onSubmit)}
              className="px-8 pt-6 pb-8 mb-4 dark:bg-gray-900 rounded"
            >
              <div className="mb-4">
                <InputSelect
                  label={"Asignacion"}
                  name={"asignacion_id"}
                  options={asignacion}
                  control={control}
                  placeholder={"Ingrese Asignacion..."}
                  errors={errors.asignacion_id?.message}
                />
              </div>

              <div className="mb-4">
                <InputSelect
                  label={"Vacuna"}
                  name={"vacuna_id"}
                  options={vacuna}
                  control={control}
                  placeholder={"Ingrese Vacuna..."}
                  errors={errors.vacuna_id?.message}
                />
              </div>

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
                  label={"Fecha Vacunacion"}
                  name={"fecha_vacunacion"}
                  type={"date"}
                  placeholder={"Ingrese Fecha Vacunacion..."}
                  register={register}
                  errors={errors.fecha_vacunacion?.message}
                />
              </div>

              <div className="mb-4">
                <InputText
                  label={"Dosis"}
                  name={"dosis"}
                  type={"number"}
                  placeholder={"Ingrese Dosis..."}
                  register={register}
                  errors={errors.dosis?.message}
                />
              </div>

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

export default VacunacionNew;
