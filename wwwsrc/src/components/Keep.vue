<template>
    <div>
        <ul>
            <!-- <li v-for="keep in vault"> -->
                <h3 class="keep-body">{{keep.body}}</h3>
                <select v-model="selected" @change="moveKeep(keep)">
                    <option disabled value="">Move to Vault:</option>
                    <!-- <option v-for="vault in vaults" v-if="keep.parentId!=vault._id" v-bind:value="keep._id">{{vault.title}}</option> -->
                </select>
                <button @click="deleteKeep(keep)">Delete Keep</button>
            <!-- </li> -->
        </ul>
    </div>
</template>

<script>
import router from '../router'
export default {
  name: "Keeps",
  data() {
    return {
      keep: {
        body: "",
        parentId: ""
      }
    };
  },
  components: {},
  mounted() {
    this.$store.dispatch("getKeeps");
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    keeps() {
      return this.$store.state.keeps;
    }
  },
  methods: {
    setVault(keep) {
      this.$store.dispatch("setKeep", keep);
    },
    deleteKeep(keep) {
      this.$store.dispatch("deleteKeep", keep);
    },
    moveKeep(keep) {
      keep.parentId = this.selected;
      this.$store.dispatch("moveKeep", keep);
      this.selected = "";
    }
  }
};
</script>

<style>
</style>